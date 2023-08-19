using MusicLibrary.Core.Models;

namespace MusicLibrary.Tests.Setup.Fakers.Models;

internal static class ArtistModelFake
{
    public static Artist Valid => new Faker<Artist>()
        .RuleFor(artist => artist.Id, _ => Guid.NewGuid())
        .RuleFor(artist => artist.GenreId, _ => Guid.NewGuid())
        .RuleFor(artist => artist.Name, faker => faker.Random.Word())
        .RuleFor(artist => artist.CreatedAt, _ => DateTime.UtcNow)
        .RuleFor(artist => artist.UpdatedAt, _ => default)
        .RuleFor(artist => artist.IsDisabled, _ => default)
        .Generate();
}