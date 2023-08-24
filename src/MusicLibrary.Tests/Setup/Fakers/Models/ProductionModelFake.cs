using System.Globalization;
using MusicLibrary.Core.Enums;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Tests.Setup.Fakers.Models;

internal static class ProductionModelFake
{
    public static Production Valid => new Faker<Production>()
        .RuleFor(production => production.ArtistId, _ => Guid.NewGuid())
        .RuleFor(production => production.Title, faker => faker.Random.Word())
        .RuleFor(production => production.Category, faker => faker.PickRandom<Category>())
        .RuleFor(production => production.ReleaseDate,
            _ => DateTime.UtcNow.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
        .Generate();
}