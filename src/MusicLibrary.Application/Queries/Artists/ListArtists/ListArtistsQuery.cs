using MediatR;
using MusicLibrary.Application.Responses.Artists;
using MusicLibrary.Application.Utils;
using MusicLibrary.Application.Utils.Abstract;

namespace MusicLibrary.Application.Queries.Artists.ListArtists;

public class ListArtistsQuery : BasicQuery, IRequest<ApiResult<IEnumerable<DefaultArtistResponse>>>
{
}