using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Application.Commands.Users.AccessToken;
using MusicLibrary.Application.Responses.Users;
using MusicLibrary.Application.Utils;
using MusicLibrary.Presentation.Controllers.Abstract;

namespace MusicLibrary.Presentation.Controllers;

/// <summary>
/// API Controller to handle requests related to Users.
/// </summary>
[ApiController, ApiVersion("1"), Produces(ContentTypes.Json)]
[Authorize(Roles = AuthorizationRoles.AdminUser)]
[Route("api/[controller]/v{version:ApiVersion}")]
public class UsersController : ResponseHandlerController
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Public constructor to initialize an instance of <see cref="IMediator"/>.
    /// </summary>
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Creates an access token for the user.
    /// </summary>
    /// <response code="200">Returns essential user information along with access token.</response>
    /// <response code="400">There was an error when trying to validate the request.</response>
    [AllowAnonymous]
    [HttpPost("token", Name = "create-access-token")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(CreatedAccessTokenResponse))]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(string))]
    public async Task<IActionResult> CreateAccessTokenAsync([FromBody, Required] CreateAccessTokenCommand command, CancellationToken cancellationToken = default)
    {
        var apiResult = await _mediator.Send(command, cancellationToken);
        return BuildResponse(apiResult);
    }
}