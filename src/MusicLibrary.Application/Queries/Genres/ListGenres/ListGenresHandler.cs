using MediatR;
using Microsoft.AspNetCore.Http;
using MusicLibrary.Application.Responses.Genres;
using MusicLibrary.Application.Utils;
using MusicLibrary.Core.Contracts.Repositories;

namespace MusicLibrary.Application.Queries.Genres.ListGenres;

public class ListGenresHandler : IRequestHandler<ListGenreQuery, ApiResult<IEnumerable<DefaultGenreResponse>>>
{
    private readonly IGenreRepository _genreRepository;

    public ListGenresHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<ApiResult<IEnumerable<DefaultGenreResponse>>> Handle(ListGenreQuery request,
        CancellationToken cancellationToken)
    {
        var apiResult = new ApiResult<IEnumerable<DefaultGenreResponse>>();
        var validation = await new ListGenreValidator().ValidateAsync(request, cancellationToken);

        if (!validation.IsValid)
        {
            apiResult.StatusCode = StatusCodes.Status400BadRequest;
            apiResult.ErrorMessage = validation.Errors.Single().ErrorMessage;
        }
        else
        {
            apiResult.Response = Enumerable.Empty<DefaultGenreResponse>();
            var genres = _genreRepository
                .Query(genre => !genre.IsDisabled, isReadOnly: true)
                .ToList();

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                genres = genres
                    .Where(genre => genre.Name.Contains(request.Name, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            genres = (request.OrderBy.Equals("desc", StringComparison.OrdinalIgnoreCase)
                    ? genres.OrderByDescending(genre => genre.Name)
                    : genres.OrderBy(genre => genre.Name))
                .ToList();

            genres.ForEach(genre =>
            {
                apiResult.Response = apiResult.Response.Append(new DefaultGenreResponse
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            });
        }

        return apiResult;
    }
}