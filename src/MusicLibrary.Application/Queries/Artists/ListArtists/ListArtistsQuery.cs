using MediatR;
using MusicLibrary.Application.Responses.Artists;
using MusicLibrary.Application.Utils;

namespace MusicLibrary.Application.Queries.Artists.ListArtists;

public class ListArtistsQuery : IRequest<ApiResult<IEnumerable<DefaultArtistResponse>>>
{
    public string Name { get; set; } = default;
    public string OrderBy { get; set; } = "asc";
}