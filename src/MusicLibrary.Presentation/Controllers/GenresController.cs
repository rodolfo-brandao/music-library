using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Application.Queries.Genres.ListGenres;
using MusicLibrary.Application.Responses.Genres;
using MusicLibrary.Application.Utils;
using MusicLibrary.Presentation.Controllers.Abstract;

namespace MusicLibrary.Presentation.Controllers;

/// <summary>
/// API Controller to handle requests related to music genres.
/// </summary>
[ApiController, ApiVersion("1"), Produces(ContentTypes.Json)]
[Authorize(Roles = AuthorizationRoles.AdminUser)]
[Route("api/[controller]/v{version:ApiVersion}")]
public class GenresController : ResponseHandlerController
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Public constructor to inject <paramref name="mediator"/>.
    /// </summary>
    public GenresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Lists all genres.
    /// </summary>
    /// <param name="query">The object containing the query params.</param>
    /// <param name="cancellationToken">The cancellation token object.</param>
    /// <response code="200">Returns a list containing all genres.</response>
    [HttpGet(Name = "list-genres")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(DefaultGenreResponse[]))]
    public async Task<IActionResult> ListGenresAsync([FromQuery] ListGenreQuery query,
        CancellationToken cancellationToken = default)
        => BuildResponse(await _mediator.Send(query, cancellationToken));
}