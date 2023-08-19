using MediatR;
using MusicLibrary.Application.Queries.Abstract;
using MusicLibrary.Application.Responses.Artists;
using MusicLibrary.Application.Utils;

namespace MusicLibrary.Application.Queries.Artists.ListArtists;

public class ListArtistsQuery : BasicQuery, IRequest<ApiResult<IEnumerable<DefaultArtistResponse>>>
{
}