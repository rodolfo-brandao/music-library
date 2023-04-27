namespace MusicLibrary.Application.Utils;

/// <summary>
/// A collection of role constants that are used to authorize API requests.
/// </summary>
public static class AuthorizationRoles
{
    public const string Admin = "admin";
    public const string AdminUser = "admin,user";
    public const string User = "user";
}