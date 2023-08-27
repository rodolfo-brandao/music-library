using System.Collections;
using MusicLibrary.Application.Commands.Users.AccessToken;
using MusicLibrary.Application.Responses.Users;
using MusicLibrary.Application.Utils;
using MusicLibrary.Tests.Setup.Builders.Services;
using MusicLibrary.Tests.Setup.Fakers.Commands.Users.AccessToken;
using MusicLibrary.Tests.Setup.Fakers.Models;
using Serilog;

namespace MusicLibrary.Tests.Application.Commands.Users.AccessToken;

[Trait("Handler", "CreateAccessToken")]
public class CreateAccessTokenHandlerTest
{
    private readonly ILogger _logger;

    public CreateAccessTokenHandlerTest()
    {
        _logger = new Mock<ILogger>().Object;
    }

    [Fact(DisplayName = "[async] Handle() - Success Case")]
    public async Task Handle_PassValidCommandObject_HandlerShouldCreateAccessToken()
    {
        // Arrange:
        var command = CreateAccessTokenCommandFake.Valid;
        var user = UserModelFake.Valid(username: command.Username);

        var securityService = SecurityServiceMockBuilder
            .Create()
            .SetupCreateUserAccessToken()
            .SetupGetUserAsync(user: user)
            .SetupValidatePassword(passwordIsValid: true)
            .Build();

        var handler = new CreateAccessTokenHandler(securityService, _logger);

        // Act:
        var sut = await handler.Handle(command, cancellationToken: default);

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<ApiResult<CreatedAccessTokenResponse>>();
        sut.Response.Should().NotBeNull();
        sut.ErrorMessage.Should().BeNull();
    }

    [Theory(DisplayName = "[async] Handle() - Failure Cases (3): command object with null properties")]
    [ClassData(typeof(CreateAccessTokenInvalidCommands))]
    public async Task Handle_PassInvalidCommandObject_HandlerShouldNotCreateAccessToken(
        CreateAccessTokenCommand command)
    {
        // Arrange:
        var user = UserModelFake.Valid(username: command.Username);

        var securityService = SecurityServiceMockBuilder
            .Create()
            .SetupCreateUserAccessToken()
            .SetupGetUserAsync(user: user)
            .SetupValidatePassword(passwordIsValid: true)
            .Build();

        var handler = new CreateAccessTokenHandler(securityService, _logger);

        // Act:
        var sut = await handler.Handle(command, cancellationToken: default);

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<ApiResult<CreatedAccessTokenResponse>>();
        sut.Response.Should().BeNull();
        sut.ErrorMessage.Should().NotBeNullOrWhiteSpace();
    }
}

/// <summary>
/// Utility class to provide invalid command objects in test methods.
/// </summary>
internal class CreateAccessTokenInvalidCommands : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            CreateAccessTokenCommandFake.WithNullUsername
        };

        yield return new object[]
        {
            CreateAccessTokenCommandFake.WithNullUPassword
        };

        yield return new object[]
        {
            CreateAccessTokenCommandFake.WithAllPropertiesNull
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}