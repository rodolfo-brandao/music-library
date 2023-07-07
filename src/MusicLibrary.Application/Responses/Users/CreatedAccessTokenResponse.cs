namespace MusicLibrary.Application.Responses.Users;

public class CreatedAccessTokenResponse
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string AccessToken { get; set; }
}