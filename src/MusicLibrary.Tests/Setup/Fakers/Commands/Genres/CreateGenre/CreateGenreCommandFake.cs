using MusicLibrary.Application.Commands.Genres.CreateGenre;

namespace MusicLibrary.Tests.Setup.Fakers.Commands.Genres.CreateGenre;

internal static class CreateGenreCommandFake
{
    private const ushort MaxNameLength = 50;

    public static CreateGenreCommand Valid(string name = default) => new Faker<CreateGenreCommand>()
        .RuleFor(command => command.Name, faker => name ?? faker.Random.Word())
        .Generate();

    #region Invalid Command Objects

    public static CreateGenreCommand WithNullName => new Faker<CreateGenreCommand>()
        .RuleFor(command => command.Name, _ => default)
        .Generate();

    public static CreateGenreCommand WithNameLengthExceeded => new Faker<CreateGenreCommand>()
        .RuleFor(command => command.Name, faker => faker.Random.String(length: MaxNameLength + 1))
        .Generate();

    #endregion
}