using System.Collections;
using MusicLibrary.Application.Commands.Users.CreateUser;
using MusicLibrary.Application.Responses.Users;
using MusicLibrary.Application.Utils;
using MusicLibrary.Tests.Setup.Builders.Services;
using MusicLibrary.Tests.Setup.Fakers.Commands.Users.CreateUser;
using MusicLibrary.Tests.Setup.Fakers.Models;
using Serilog;

namespace MusicLibrary.Tests.Application.Commands.Users.CreateUser;

[Trait("Handler", "CreateUser")]
public class CreateUserHandlerTest
{
    private readonly ILogger _logger;

    public CreateUserHandlerTest()
    {
        _logger = new Mock<ILogger>().Object;
    }

    [Fact(DisplayName = "[async] Handle() - Success Case")]
    public async Task Handle_PassValidCommandObject_HandlerShouldCreateNewUser()
    {
        // Arrange:
        var command = CreateUserCommandFake.Valid();

        var securityService = SecurityServiceMockBuilder
            .Create()
            .SetupGetUserAsync()
            .Build();

        var handler = new CreateUserHandler(securityService, _logger);

        // Act:
        var sut = await handler.Handle(command, cancellationToken: default);

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<ApiResult<CreatedUserResponse>>();
        sut.Response.Should().NotBeNull();
        sut.ErrorMessage.Should().BeNull();
    }

    [Fact(DisplayName = "[async] Handle() - Failure Case: username already exists in database")]
    public async Task Handle_PassCommandObjectWithUsernameThatExists_HandlerShouldNotCreateUser()
    {
        // Arrange:
        var command = CreateUserCommandFake.Valid();
        var user = UserModelFake.Valid(username: command.Username);

        var securityService = SecurityServiceMockBuilder
            .Create()
            .SetupGetUserAsync(userModelToBeReturned: user)
            .Build();

        var handler = new CreateUserHandler(securityService, _logger);

        // Act:
        var sut = await handler.Handle(command, cancellationToken: default);

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<ApiResult<CreatedUserResponse>>();
        sut.Response.Should().BeNull();
        sut.ErrorMessage.Should().NotBeNullOrWhiteSpace();
    }


    [Theory(DisplayName =
        "[async] Handle() - Failure Cases (4): command object with invalid properties (null & empty)")]
    [ClassData(typeof(CreateUserInvalidCommands))]
    public async Task Handle_PassInvalidCommandObject_HandlerShouldNotCreateUser(CreateUserCommand command)
    {
        // Arrange:
        var securityService = SecurityServiceMockBuilder
            .Create()
            .SetupGetUserAsync()
            .Build();

        var handler = new CreateUserHandler(securityService, _logger);

        // Act:
        var sut = await handler.Handle(command, cancellationToken: default);

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<ApiResult<CreatedUserResponse>>();
        sut.Response.Should().BeNull();
        sut.ErrorMessage.Should().NotBeNullOrWhiteSpace();
    }
}

/// <summary>
/// Utility class to provide invalid command objects in test methods.
/// </summary>
internal class CreateUserInvalidCommands : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            CreateUserCommandFake.WithNullUsername
        };

        yield return new object[]
        {
            CreateUserCommandFake.WithNullPassword
        };

        yield return new object[]
        {
            CreateUserCommandFake.WithUsernameExceededLength
        };

        yield return new object[]
        {
            CreateUserCommandFake.WithWrongPasswordMinLength
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}