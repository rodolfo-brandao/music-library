using MediatR;
using MusicLibrary.Application.Responses.Genres;
using MusicLibrary.Application.Utils;

namespace MusicLibrary.Application.Commands.Genres.CreateGenre;

public class CreateGenreCommand : IRequest<ApiResult<CreatedGenreResponse>>
{
    public string Name { get; init; }
}