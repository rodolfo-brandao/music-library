using MusicLibrary.Application.Commands.Users.CreateUser;

namespace MusicLibrary.Tests.Setup.Fakers.Commands.Users.CreateUser;

internal static class CreateUserCommandFake
{
    private const ushort MaxUsernameLength = 50;
    private const ushort MinPasswordLength = 6;

    public static CreateUserCommand Valid(bool isAdmin = default) => new Faker<CreateUserCommand>()
        .RuleFor(command => command.Username, faker => faker.Internet.UserName())
        .RuleFor(command => command.Password, faker => faker.Random.Hash())
        .RuleFor(command => command.IsAdmin, _ => isAdmin)
        .Generate();

    # region Invalid Commands

    public static CreateUserCommand WithNullUsername => new Faker<CreateUserCommand>()
        .RuleFor(command => command.Username, _ => default)
        .RuleFor(command => command.Password, faker => faker.Random.Hash())
        .RuleFor(command => command.IsAdmin, _ => default)
        .Generate();

    public static CreateUserCommand WithNullPassword => new Faker<CreateUserCommand>()
        .RuleFor(command => command.Username, faker => faker.Internet.UserName())
        .RuleFor(command => command.Password, _ => default)
        .RuleFor(command => command.IsAdmin, _ => default)
        .Generate();

    public static CreateUserCommand WithUsernameExceededLength => new Faker<CreateUserCommand>()
        .RuleFor(command => command.Username, faker => faker.Random.String(length: MaxUsernameLength + 1))
        .RuleFor(command => command.Password, faker => faker.Random.Hash())
        .RuleFor(command => command.IsAdmin, _ => default)
        .Generate();

    public static CreateUserCommand WithWrongPasswordMinLength => new Faker<CreateUserCommand>()
        .RuleFor(command => command.Username, faker => faker.Internet.UserName())
        .RuleFor(command => command.Password, faker => faker.Random.Hash(length: MinPasswordLength - 1))
        .RuleFor(command => command.IsAdmin, _ => default)
        .Generate();

    #endregion
}