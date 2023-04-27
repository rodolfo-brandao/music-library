using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MusicLibrary.Application.Extensions;
using MusicLibrary.Core.Contracts.Services;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Application.Services;

public class SecurityService : ISecurityService
{
    private readonly IConfiguration _configuration;

    public SecurityService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public (string PasswordHash, string PasswordSalt) CreatePasswordHash(string rawPassword)
    {
        var salt = CreateSalt();
        return (CreateHash(rawPassword, salt), salt);
    }

    public string CreateUserAccessToken(User user)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Secret").Value ?? string.Empty));
        var signInCredentials = new SigningCredentials(key, algorithm: SecurityAlgorithms.HmacSha512Signature);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = signInCredentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(securityToken);
    }

    public bool ValidatePassword(string rawPassword, string passwordHash, string passwordSalt) =>
        CreateHash(rawPassword, passwordSalt).Equals(passwordHash);

    #region Private methods

    private static string CreateHash(string rawPassword, string salt)
    {
        var hash = MD5.HashData(Encoding.UTF8.GetBytes($"{rawPassword}{salt}"));
        return hash.ParseToString(format: "x2");
    }

    private static string CreateSalt(int size = 12)
    {
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        var bytes = new byte[size];
        randomNumberGenerator.GetBytes(bytes);
        return bytes.ParseToString(format: "x2");
    }

    #endregion
}