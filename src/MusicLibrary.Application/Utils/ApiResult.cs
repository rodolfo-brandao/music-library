namespace MusicLibrary.Application.Utils;

public class ApiResult<TResponse>
{
    public int StatusCode { get; }
    public TResponse Response { get; set; }
    public string ErrorMessage { get; set; }

    public ApiResult(int statusCode)
    {
        StatusCode = statusCode;
        Response = default;
        ErrorMessage = default;
    }
}