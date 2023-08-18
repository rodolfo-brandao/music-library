using System.Collections;
using MusicLibrary.Application.Commands.Users.AccessToken;
using MusicLibrary.Application.Responses.Users;
using MusicLibrary.Application.Utils;
using MusicLibrary.Tests.Setup.Builders.Repositories;
using MusicLibrary.Tests.Setup.Builders.Services;
using MusicLibrary.Tests.Setup.Fakers.Commands.Users.AccessToken;
using MusicLibrary.Tests.Setup.Fakers.Models;
using Serilog;

namespace MusicLibrary.Tests.Application.Users.Commands.AccessToken;

[Trait("Handler", "CreateAccessToken")]
public class CreateAccessTokenHandlerTest
{
    private readonly ILogger _logger;

    public CreateAccessTokenHandlerTest()
    {
        _logger = new Mock<ILogger>().Object;
    }

    [Fact(DisplayName = "Handle() - Success Case")]
    public async Task Handle_PassValidCommandObject_HandlerShouldCreateAccessToken()
    {
        // Arrange:
        var command = CreateAccessTokenCommandFake.Valid;
        var user = UserModelFake.Valid(username: command.Username);
        var cancellationToken = default(CancellationToken);

        var userRepository = UserRepositoryMockBuilder
            .Create()
            .SetupGetByUsernameAsync(userModelToBeReturned: user)
            .Build();

        var securityService = SecurityServiceMockBuilder
            .Create()
            .SetupValidatePassword(passwordIsValid: true)
            .SetupCreateUserAccessToken()
            .Build();

        var handler = new CreateAccessTokenHandler(userRepository, securityService, _logger);

        // Act:
        var sut = await handler.Handle(command, cancellationToken);

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<ApiResult<CreatedAccessTokenResponse>>();
        sut.Response.Should().NotBeNull();
        sut.ErrorMessage.Should().BeNull();
    }

    [Theory(DisplayName = "Handle() - Failure Cases (3): command object with null properties")]
    [ClassData(typeof(CreateAccessTokenInvalidCommands))]
    public async Task Handle_PassInvalidCommandObject_HandlerShouldNotCreateAccessToken(
        CreateAccessTokenCommand command)
    {
        // Arrange:
        var user = UserModelFake.Valid(username: command.Username);
        var cancellationToken = default(CancellationToken);

        var userRepository = UserRepositoryMockBuilder
            .Create()
            .SetupGetByUsernameAsync(userModelToBeReturned: user)
            .Build();

        var securityService = SecurityServiceMockBuilder
            .Create()
            .SetupValidatePassword(passwordIsValid: true)
            .SetupCreateUserAccessToken()
            .Build();

        var handler = new CreateAccessTokenHandler(userRepository, securityService, _logger);

        // Act:
        var sut = await handler.Handle(command, cancellationToken);

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