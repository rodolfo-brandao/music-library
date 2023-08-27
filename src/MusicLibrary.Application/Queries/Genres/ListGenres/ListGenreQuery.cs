using MediatR;
using MusicLibrary.Application.Responses.Genres;
using MusicLibrary.Application.Utils;
using MusicLibrary.Application.Utils.Abstract;

namespace MusicLibrary.Application.Queries.Genres.ListGenres;

public class ListGenreQuery : BasicQuery, IRequest<ApiResult<IEnumerable<DefaultGenreResponse>>>
{
}