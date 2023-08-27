using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models;

public class User : TrackableEntity
{
    public virtual string Username { get; protected internal set; }
    public virtual string Password { get; protected internal set; }
    public virtual string PasswordSalt { get; protected internal set; }
    public virtual string Role { get; protected internal set; }

    public virtual User ChangeUsername(string username)
    {
        Username = username;
        return this;
    }

    public virtual User ChangePassword(string password, string passwordSalt)
    {
        (Password, PasswordSalt) = (password, passwordSalt);
        return this;
    }

    public virtual User ChangeRole(string role)
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
        UpdatedOn = DateTime.UtcNow;
        return this;
    }
}