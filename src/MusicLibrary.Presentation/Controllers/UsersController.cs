using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Application.Commands.Users.AccessToken;
using MusicLibrary.Application.Commands.Users.CreateUser;
using MusicLibrary.Application.Responses.Users;
using MusicLibrary.Application.Utils;
using MusicLibrary.Presentation.Controllers.Abstract;

namespace MusicLibrary.Presentation.Controllers;

/// <summary>
/// API Controller to handle requests related to system users.
/// </summary>
[ApiController, ApiVersion("1"), Produces(ContentTypes.Json)]
[Authorize(Roles = AuthorizationRoles.AdminUser)]
[Route("api/[controller]/v{version:ApiVersion}")]
public class UsersController : ResponseHandlerController
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Public constructor to inject <paramref name="mediator"/>.
    /// </summary>
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Creates an access token for the user.
    /// </summary>
    /// <param name="command">The request body.</param>
    /// <param name="cancellationToken">The cancellation token object.</param>
    /// <response code="200">Returns the access token along with essential information.</response>
    /// <response code="400">There was an error when trying to validate the request.</response>
    [AllowAnonymous]
    [HttpPost("token", Name = "create-access-token")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(CreatedAccessTokenResponse))]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(string))]
    public async Task<IActionResult> CreateAccessTokenAsync([FromBody] CreateAccessTokenCommand command,
        CancellationToken cancellationToken = default)
        => BuildResponse(await _mediator.Send(command, cancellationToken));

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="command">The request body.</param>
    /// <param name="cancellationToken">The cancellation token object.</param>
    /// <response code="201">Returns essential user information along with access token.</response>
    /// <response code="400">There was an error when trying to validate the request.</response>
    [AllowAnonymous]
    [HttpPost(Name = "create-user")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(CreatedUserResponse))]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(string))]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command,
        CancellationToken cancellationToken = default)
        => BuildResponse(await _mediator.Send(command, cancellationToken));
}