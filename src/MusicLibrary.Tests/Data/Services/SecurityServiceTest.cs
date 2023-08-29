using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using MusicLibrary.Data.Services;
using MusicLibrary.Tests.Setup.Builders.Microsoft.Extensions.Configuration;
using MusicLibrary.Tests.Setup.Builders.StackExchange.Redis;
using MusicLibrary.Tests.Setup.Fakers.Models;

namespace MusicLibrary.Tests.Data.Services;

[Trait("Service", "Security")]
public partial class SecurityServiceTest
{
    private readonly Faker _faker;

    public SecurityServiceTest()
    {
        _faker = new Faker();
    }

    [Fact(DisplayName = "CreatePasswordHash() - Success Case")]
    public void CreatePasswordHash_PassRawPasswordString_ServiceShouldCreatePasswordHash()
    {
        // Arrange:
        const ushort expectedPasswordHashLength = 32;
        const ushort expectedPasswordSaltLength = 24;
        var rawPassword = _faker.Random.String();
        var configuration = ConfigurationMockBuilder.Create().Build();
        var connectionMultiplexer = ConnectionMultiplexerMockBuilder.Create().Build();
        var securityService = new SecurityService(configuration, connectionMultiplexer);

        // Act:
        var sut = securityService.CreatePasswordHash(rawPassword);

        // Assert:
        sut.Should().BeOfType<(string, string)>();
        sut.PasswordHash.Should().NotBeNullOrWhiteSpace().And.HaveLength(expectedPasswordHashLength);
        sut.PasswordSalt.Should().NotBeNullOrWhiteSpace().And.HaveLength(expectedPasswordSaltLength);
    }

    [Fact(DisplayName = "CreateUserAccessToken() - Success Case")]
    public void CreateUserAccessToken_PassValidUserModel_ServiceShouldCreateAccessTokenForUser()
    {
        // Arrange:
        var jwtSecretKey = $"{Guid.NewGuid()}.{Guid.NewGuid()}";
        var user = UserModelFake.Valid();

        var configuration = ConfigurationMockBuilder
            .Create()
            .SetupGetSection(jwtSecretKey)
            .Build();

        var connectionMultiplexer = ConnectionMultiplexerMockBuilder.Create().Build();
        var securityService = new SecurityService(configuration, connectionMultiplexer);

        // Act:
        var sut = securityService.CreateUserAccessToken(user);

        // Assert:
        sut.Should().BeOfType<string>().And.NotBeNullOrWhiteSpace();
    }

    [Fact(DisplayName = "ValidatePassword() - Success Case")]
    public void ValidatePassword_PassCorrectPassword_SecurityServiceShouldIndicateValidPassword()
    {
        // Arrange:
        var rawPassword = _faker.Random.String();
        var configuration = ConfigurationMockBuilder.Create().Build();
        var connectionMultiplexer = ConnectionMultiplexerMockBuilder.Create().Build();
        var securityService = new SecurityService(configuration, connectionMultiplexer);

        // Act:
        var password = securityService.CreatePasswordHash(rawPassword);
        var sut = securityService.ValidatePassword(rawPassword, password.PasswordHash, password.PasswordSalt);

        // Assert:
        sut.Should().BeTrue();
    }
}