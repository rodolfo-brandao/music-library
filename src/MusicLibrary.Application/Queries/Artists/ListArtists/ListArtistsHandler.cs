using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Application.Responses.Artists;
using MusicLibrary.Application.Utils;
using MusicLibrary.Core.Contracts.Repositories;

namespace MusicLibrary.Application.Queries.Artists.ListArtists;

public class ListArtistsHandler : IRequestHandler<ListArtistsQuery, ApiResult<IEnumerable<DefaultArtistResponse>>>
{
    private readonly IArtistRepository _artistRepository;

    public ListArtistsHandler(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<ApiResult<IEnumerable<DefaultArtistResponse>>> Handle(ListArtistsQuery request, CancellationToken cancellationToken)
    {
        var apiResult = new ApiResult<IEnumerable<DefaultArtistResponse>>();
        var validation = await new ListArtistsQueryValidator().ValidateAsync(request, cancellationToken);

        if (!validation.IsValid)
        {
            apiResult.StatusCode = StatusCodes.Status400BadRequest;
            apiResult.ErrorMessage = validation.Errors.Single().ErrorMessage;
        }
        else
        {
            var artists = await _artistRepository.Query(artist => !artist.IsDisabled, isReadOnly: true).ToListAsync();

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                artists = artists.Where(artist => artist.Name.Contains(request.Name, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            artists = request.OrderBy.Equals("desc", StringComparison.OrdinalIgnoreCase)
                ? artists.OrderByDescending(artist => artist.Name).ToList()
                : artists.OrderBy(artist => artist.Name).ToList();

            artists.ForEach(artist => apiResult.Response.Append(new DefaultArtistResponse
            {
                Id = artist.Id,
                Name = artist.Name
            }));
        }

        return apiResult;
    }
}
