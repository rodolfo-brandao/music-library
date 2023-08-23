using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Application.Queries.Artists.ListArtists;
using MusicLibrary.Application.Responses.Artists;
using MusicLibrary.Application.Utils;
using MusicLibrary.Presentation.Controllers.Abstract;

namespace MusicLibrary.Presentation.Controllers;

/// <summary>
/// API Controller to handle requests related to musical artists.
/// </summary>
[ApiController, ApiVersion("1"), Produces(ContentTypes.Json)]
[Authorize(Roles = AuthorizationRoles.AdminUser)]
[Route("api/[controller]/v{version:ApiVersion}")]
public class ArtistsController : ResponseHandlerController
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Public constructor to inject <paramref name="mediator"/>.
    /// </summary>
    public ArtistsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Lists all artists.
    /// </summary>
    /// <param name="query">The object containing the query params.</param>
    /// <param name="cancellationToken">The cancellation token object.</param>
    /// <response code="200">Returns a list containing all artists.</response>
    [HttpGet(Name = "list-artists")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(DefaultArtistResponse[]))]
    public async Task<IActionResult> ListArtistsAsync([FromQuery] ListArtistsQuery query,
        CancellationToken cancellationToken = default)
        => BuildResponse(await _mediator.Send(query, cancellationToken));
}