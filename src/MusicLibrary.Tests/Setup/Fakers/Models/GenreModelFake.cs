using MusicLibrary.Core.Models;

namespace MusicLibrary.Tests.Setup.Fakers.Models;

internal static class GenreModelFake
{
    public static Genre Valid => new Faker<Genre>()
        .RuleFor(genre => genre.Id, _ => Guid.NewGuid())
        .RuleFor(genre => genre.Name, faker => faker.Random.Word())
        .RuleFor(genre => genre.CreatedAt, _ => DateTime.UtcNow)
        .RuleFor(genre => genre.UpdatedAt, _ => default)
        .RuleFor(genre => genre.IsDisabled, _ => default)
        .Generate();
}