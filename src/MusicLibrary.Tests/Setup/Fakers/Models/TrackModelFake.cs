using MusicLibrary.Core.Models;

namespace MusicLibrary.Tests.Setup.Fakers.Models;

internal static class TrackModelFake
{
    public static Track Valid => new Faker<Track>()
        .RuleFor(track => track.ProductionId, _ => Guid.NewGuid())
        .RuleFor(track => track.Position, faker => faker.Random.Byte())
        .RuleFor(track => track.Title, faker => faker.Random.Word())
        .RuleFor(track => track.Length, faker => faker.Random.Float())
        .Generate();
}