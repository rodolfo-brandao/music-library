using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models;

public class User : TrackableEntity
{
    public string Username { get; protected set; }
    public string Email { get; protected set; }
    public string Password { get; protected set; }
    public string PasswordSalt { get; protected set; }
    public string Role { get; protected set; }

    public User(string username, string email, string password, string passwordSalt, string role)
    {
        Id = Guid.NewGuid();
        Username = username;
        Email = email;
        Password = password;
        PasswordSalt = passwordSalt;
        Role = role;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = default;
        IsDisabled = default;
    }

    public User ChangeUsername(string username)
    {
        Username = username;
        return this;
    }

    public User ChangeEmail(string email)
    {
        Email = email;
        return this;
    }

    public User ChangePassword(string password, string passwordSalt)
    {
        (Password, PasswordSalt) = (password, passwordSalt);
        return this;
    }

    public User ChangeRole(string role)
    {
        Role = role;
        return this;
    }

    public override TrackableEntity Disable()
    {
        IsDisabled = true;
        return this;
    }

    public override TrackableEntity Enable()
    {
        IsDisabled = default;
        return this;
    }

    public override TrackableEntity UpdateNow()
    {
        UpdatedAt = DateTime.UtcNow;
        return this;
    }
}