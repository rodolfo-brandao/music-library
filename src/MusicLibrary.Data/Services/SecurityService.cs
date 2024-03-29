using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MusicLibrary.Core.Contracts.Services;
using MusicLibrary.Core.Models;
using MusicLibrary.Core.Models.Nulls;
using MusicLibrary.Data.ContractResolvers;
using MusicLibrary.Data.Extensions;
using Newtonsoft.Json;
using StackExchange.Redis;
using IRedisDatabase = StackExchange.Redis.IDatabase;

namespace MusicLibrary.Data.Services;

public class SecurityService : ISecurityService
{
    private readonly IConfiguration _configuration;
    private readonly IRedisDatabase _redisDatabase;

    public SecurityService(IConfiguration configuration, IConnectionMultiplexer connectionMultiplexer)
    {
        _configuration = configuration;
        _redisDatabase = connectionMultiplexer.GetDatabase();
    }

    public (string PasswordHash, string PasswordSalt) CreatePasswordHash(string rawPassword)
    {
        var salt = CreateSalt();
        return (CreateHash(rawPassword, salt), salt);
    }

    public async Task<bool> CreateUserAsync(User user)
    {
        var redisKey = new RedisKey(user.Username);
        var redisValue = new RedisValue(JsonConvert.SerializeObject(user));
        return await _redisDatabase.StringSetAsync(redisKey, redisValue);
    }

    public string CreateUserAccessToken(User user)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Secret").Value ?? string.Empty));
        var signInCredentials = new SigningCredentials(key, algorithm: SecurityAlgorithms.HmacSha512Signature);

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Id.ToString()),
            new(ClaimTypes.Role, user.Role)
        };

        const ushort oneHour = 1;
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(oneHour),
            SigningCredentials = signInCredentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(securityToken);
    }

    public async Task<User> GetUserAsync(string username)
    {
        var record = (await _redisDatabase.StringGetAsync(new RedisKey(username))).ToString();
        return !string.IsNullOrWhiteSpace(record)
            ? JsonConvert.DeserializeObject<User>(record, new JsonSerializerSettings
            {
                ContractResolver = new NonPublicPropertiesContractResolver()
            })
            : new NullUser();
    }

    public async Task<bool> RemoveUserAsync(string username)
        => await _redisDatabase.KeyDeleteAsync(new RedisKey(username));

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