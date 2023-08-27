using MediatR;
using MusicLibrary.Application.Responses.Users;
using MusicLibrary.Application.Utils;

namespace MusicLibrary.Application.Commands.Users.CreateUser;

public class CreateUserCommand : IRequest<ApiResult<CreatedUserResponse>>
{
    public string Username { get; set; }

    public string Password { get; set; }

    public bool IsAdmin { get; set; }
}