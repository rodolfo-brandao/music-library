using MediatR;
using MusicLibrary.Application.Responses.Users;
using MusicLibrary.Application.Utils;

namespace MusicLibrary.Application.Commands.Users.AccessToken;

public class CreateAccessTokenCommand : IRequest<ApiResult<CreatedAccessTokenResponse>>
{
    public string Username { get; set; }

    public string Password { get; set; }
}