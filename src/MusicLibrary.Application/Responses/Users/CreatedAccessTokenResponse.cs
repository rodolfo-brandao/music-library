namespace MusicLibrary.Application.Responses.Users;

public class CreatedAccessTokenResponse
{
    public string AccessToken { get; init; }
    public string TokenType { get; init; }
    public ushort ExpiresIn { get; init; }
}