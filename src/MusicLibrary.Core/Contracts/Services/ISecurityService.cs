using MusicLibrary.Core.Models;

namespace MusicLibrary.Core.Contracts.Services;

public interface ISecurityService
{
    (string PasswordHash, string PasswordSalt) CreatePasswordHash(string rawPassword);
    string CreateUserAccessToken(User user);
    bool ValidatePassword(string rawPassword, string passwordHash, string passwordSalt);
}