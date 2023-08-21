using MusicLibrary.Core.Models;

namespace MusicLibrary.Core.Contracts.Services;

public interface ISecurityService
{
    (string PasswordHash, string PasswordSalt) CreatePasswordHash(string rawPassword);
    Task<bool> CreateUserAsync(User user);
    string CreateUserAccessToken(User user);
    Task<User> GetUserAsync(string username);
    Task<bool> RemoveUserAsync(string username);
    bool ValidatePassword(string rawPassword, string passwordHash, string passwordSalt);
}