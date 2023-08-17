using MusicLibrary.Application.Commands.Users.AccessToken;

namespace MusicLibrary.Tests.Setup.Fakers.Commands.Users.AccessToken;

internal static class CreateAccessTokenCommandFake
{
    public static CreateAccessTokenCommand Valid => new Faker<CreateAccessTokenCommand>()
        .RuleFor(command => command.Username, faker => faker.Internet.UserName())
        .RuleFor(command => command.Password, faker => faker.Internet.Password())
        .Generate();

    # region Invalid Commands: Null Properties

    public static CreateAccessTokenCommand WithNullUsername => new Faker<CreateAccessTokenCommand>()
        .RuleFor(command => command.Username, _ => default)
        .RuleFor(command => command.Password, faker => faker.Internet.Password())
        .Generate();

    public static CreateAccessTokenCommand WithNullUPassword => new Faker<CreateAccessTokenCommand>()
        .RuleFor(command => command.Username, faker => faker.Internet.UserName())
        .RuleFor(command => command.Password, _ => default)
        .Generate();

    public static CreateAccessTokenCommand WithAllPropertiesNull => new Faker<CreateAccessTokenCommand>()
        .RuleFor(command => command.Username, _ => default)
        .RuleFor(command => command.Password, _ => default)
        .Generate();

    # endregion
}