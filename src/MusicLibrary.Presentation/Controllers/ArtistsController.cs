using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Application.Queries.Artists.ListArtists;
using MusicLibrary.Application.Responses.Artists;
using MusicLibrary.Application.Utils;
using MusicLibrary.Presentation.Controllers.Abstract;

namespace MusicLibrary.Presentation.Controllers;

/// <summary>
/// API Controller to handle requests related to Artists.
/// </summary>
[ApiController, ApiVersion("1"), Produces(ContentTypes.Json)]
[Route("api/[controller]/v{version:ApiVersion}")]
public class ArtistsController : ResponseHandlerController
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Public constructor to initialize an instance of <see cref="IMediator"/>.
    /// </summary>
    public ArtistsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Lists all artists
    /// </summary>
    /// <response code="200">Returns a list containing all artists</response>
    [AllowAnonymous]
    [HttpGet(Name = "list-artists")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(List<DefaultArtistResponse>))]
    public async Task<IActionResult> ListArtistAsync([FromQuery] ListArtistsQuery query,
        CancellationToken cancellationToken)
    {
        var apiResult = await _mediator.Send(query, cancellationToken);
        return BuildResponse(apiResult);
    }
}