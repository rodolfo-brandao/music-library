namespace MusicLibrary.Application.Responses.Users;

public class CreatedAccessTokenResponse
{
    public string AccessToken { get; init; }
    public string TokenType { get; init; }
    
    /// <summary>
    /// Expressed in seconds. 
    /// </summary>
    public ushort ExpiresIn { get; init; }
}