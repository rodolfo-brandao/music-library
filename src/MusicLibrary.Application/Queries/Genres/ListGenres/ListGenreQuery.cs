using MediatR;
using MusicLibrary.Application.Queries.Abstract;
using MusicLibrary.Application.Responses.Genres;
using MusicLibrary.Application.Utils;

namespace MusicLibrary.Application.Queries.Genres.ListGenres;

public class ListGenreQuery : BasicQuery, IRequest<ApiResult<IEnumerable<DefaultGenreResponse>>>
{
}