using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Application.Commands.Genres.CreateGenre;
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
    /// <response code="401">You are not authorized to use this resource.</response>
    [HttpGet(Name = "list-genres")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(DefaultGenreResponse[]))]
    [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized, type: typeof(string))]
    public async Task<IActionResult> ListGenresAsync([FromQuery] ListGenreQuery query,
        CancellationToken cancellationToken = default)
        => BuildResponse(await _mediator.Send(query, cancellationToken));

    /// <summary>
    /// Creates a new genre.
    /// </summary>
    /// <param name="command">The request body object.</param>
    /// <param name="cancellationToken">The cancellation token object.</param>
    /// <response code="201">Genre created successfully.</response>
    /// <response code="401">You are not authorized to use this resource.</response>
    [HttpPost(Name = "create-genre")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(CreatedGenreResponse))]
    [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized, type: typeof(string))]
    public async Task<IActionResult> CreateGenreAsync([FromBody] CreateGenreCommand command,
        CancellationToken cancellationToken = default)
        => BuildResponse(await _mediator.Send(command, cancellationToken));
}