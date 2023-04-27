using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Application.Utils;

namespace MusicLibrary.Presentation.Controllers.Abstract;

/// <summary>
/// Abstract controller responsible for managing status code objects according to API responses.
/// </summary>
public class ResponseHandlerController : ControllerBase
{
    /// <summary>
    /// Builds the proper status code object based on the <see cref="ApiResult{TResponse}"/>.
    /// </summary>
    /// <typeparam name="TResponse">The response type.</typeparam>
    protected IActionResult BuildResponse<TResponse>(ApiResult<TResponse> apiResult)
    {
        return apiResult.StatusCode switch
        {
            StatusCodes.Status200OK => Ok(apiResult.Response),
            StatusCodes.Status201Created => CreatedAtAction(actionName: default, apiResult.Response),
            StatusCodes.Status204NoContent => NoContent(),
            StatusCodes.Status400BadRequest => BadRequest(apiResult.ErrorMessage),
            StatusCodes.Status404NotFound => NotFound(),
            _ => Problem(statusCode: StatusCodes.Status500InternalServerError),
        };
    }
}