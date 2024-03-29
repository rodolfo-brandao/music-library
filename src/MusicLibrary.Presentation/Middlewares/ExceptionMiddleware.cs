using System.Diagnostics.CodeAnalysis;
using MusicLibrary.Application.Utils;
using Newtonsoft.Json;

namespace MusicLibrary.Presentation.Middlewares;

/// <summary>
/// Middleware to handle unexpected/generic exceptions thrown by the API.
/// </summary>
[ExcludeFromCodeCoverage]
internal class ExceptionMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    /// <summary>
    /// Public constructor to initialize a instance of <see cref="RequestDelegate"/>.
    /// </summary>
    /// <param name="requestDelegate">The HTTP request to be processed.</param>
    public ExceptionMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    /// <summary>
    /// Handles all requests processed by the Application layer for any unexpected backend behavior.
    /// </summary>
    /// <param name="httpContext">The HTTP request to be processed.</param>
    /// <returns>A response with details of the exception thrown.</returns>
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _requestDelegate(httpContext);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(httpContext, e);
        }
    }

    #region Private methods

    private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var responseBody = JsonConvert.SerializeObject(new
        {
            error = exception.Message
        });

        httpContext.Response.ContentType = ContentTypes.Json;
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        return httpContext.Response.WriteAsync(responseBody);
    }

    #endregion
}