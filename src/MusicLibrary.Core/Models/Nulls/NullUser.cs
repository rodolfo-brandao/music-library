using System.Diagnostics.CodeAnalysis;
using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models.Nulls;

[ExcludeFromCodeCoverage]
public sealed class NullUser : User, INullObject
{
    public override string Username => string.Empty;
    public override string Password => string.Empty;
    public override string PasswordSalt => string.Empty;
    public override string Role => string.Empty;

    public override User ChangeUsername(string username)
    {
        return this;
    }

    public override User ChangePassword(string password, string passwordSalt)
    {
        return this;
    }

    public override User ChangeRole(string role)
    {
        return this;
    }

    public override TrackableEntity Disable()
    {
        return this;
    }

    public override TrackableEntity Enable()
    {
        return this;
    }

    public override TrackableEntity UpdateNow()
    {
        return this;
    }
}