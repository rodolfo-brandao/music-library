using Microsoft.AspNetCore.Http;

namespace MusicLibrary.Application.Utils;

public class ApiResult<TResponse>
{
    public int StatusCode { get; set; }
    public TResponse Response { get; set; }
    public string ErrorMessage { get; set; }

    public ApiResult(int statusCode = StatusCodes.Status200OK)
    {
        StatusCode = statusCode;
        Response = default;
        ErrorMessage = default;
    }
}