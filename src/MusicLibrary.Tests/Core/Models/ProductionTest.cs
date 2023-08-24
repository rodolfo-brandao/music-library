using System.Globalization;
using MusicLibrary.Core.Enums;
using MusicLibrary.Core.Factories;
using MusicLibrary.Tests.Setup.Fakers.Models;

namespace MusicLibrary.Tests.Core.Models;

[Trait("Model", "Production")]
public class ProductionTest
{
    private readonly IModelFactory _modelFactory;
    private readonly Faker _faker;

    public ProductionTest()
    {
        _modelFactory = new ModelFactory();
        _faker = new Faker();
    }

    [Fact(DisplayName = "Change...()")]
    public void Change_EditNewProduction_ModelShouldUpdateProperties()
    {
        // Arrange:
        var production = _modelFactory.CreateProduction(
            artistId: Guid.NewGuid(),
            title: _faker.Random.Word(),
            category: _faker.PickRandom<Category>(),
            releaseDate: DateTime.UtcNow.Date.AddDays(1).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));

        var anotherProduction = ProductionModelFake.Valid;

        // Act:
        production.ChangeTitle(anotherProduction.Title);
        production.ChangeCategory(anotherProduction.Category);
        production.ChangeReleaseDate(anotherProduction.ReleaseDate);

        // Assert:
        production.Title.Should().Be(anotherProduction.Title);
        production.Category.Should().Be(anotherProduction.Category);
        production.ReleaseDate.Should().Be(anotherProduction.ReleaseDate);
    }
}