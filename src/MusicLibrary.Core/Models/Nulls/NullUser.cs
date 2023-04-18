namespace MusicLibrary.Core.Models.Nulls;

public class NullUser : User
{
    public NullUser(string username, string email, string password, string passwordSalt, string role) : base(username,
        email, password, passwordSalt, role)
    {
        Id = default;
        Username = default;
        Email = default;
        Password = default;
        PasswordSalt = default;
        Role = default;
        CreatedAt = default;
        UpdatedAt = default;
        IsDisabled = default;
    }
}