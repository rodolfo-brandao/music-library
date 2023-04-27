using System.Net;
using AutoMapper;
using FluentValidation;
using MediatR;
using MusicLibrary.Application.Responses.Artists;
using MusicLibrary.Application.Utils;
using MusicLibrary.Core.Contracts.Repositories;

namespace MusicLibrary.Application.Queries.Artists.ListArtists;

public class ListArtistsHandler : IRequestHandler<ListArtistsQuery, ApiResult<List<DefaultArtistResponse>>>
{
    private readonly IArtistRepository _artistRepository;
    private readonly IMapper _mapper;

    public ListArtistsHandler(IArtistRepository artistRepository, IMapper mapper)
    {
        _artistRepository = artistRepository;
        _mapper = mapper;
    }

    public async Task<ApiResult<List<DefaultArtistResponse>>> Handle(ListArtistsQuery request,
        CancellationToken cancellationToken)
    {
        var validation = await new ListArtistsValidator
        {
            ClassLevelCascadeMode = CascadeMode.Stop
        }.ValidateAsync(request, cancellationToken);

        if (!validation.IsValid)
        {
            return new ApiResult<List<DefaultArtistResponse>>((int)HttpStatusCode.BadRequest)
            {
                ErrorMessage = validation.Errors.SingleOrDefault()?.ErrorMessage
            };
        }

        var artists = _artistRepository.Query(artist => !artist.IsDisabled, isReadOnly: true).ToList();

        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            artists = artists.Where(artist =>
                artist.Name.Contains(request.Name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        artists = request.OrderBy.Equals("desc", StringComparison.OrdinalIgnoreCase)
            ? artists.OrderByDescending(artist => artist.Name).ToList()
            : artists.OrderBy(artist => artist.Name).ToList();

        var response = _mapper.Map<List<DefaultArtistResponse>>(artists.ToList());
        var apiResult = new ApiResult<List<DefaultArtistResponse>>((int)HttpStatusCode.OK) { Response = response };
        return apiResult;
    }
}