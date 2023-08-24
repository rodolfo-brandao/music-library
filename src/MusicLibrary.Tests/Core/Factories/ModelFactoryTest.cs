using System.Globalization;
using MusicLibrary.Core.Enums;
using MusicLibrary.Core.Factories;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Tests.Core.Factories;

[Trait("Factory", "Models")]
public class ModelFactoryTest
{
    private readonly Faker _faker;
    private readonly string[] _roles;

    public ModelFactoryTest()
    {
        _faker = new Faker();
        _roles = new[] { "admin", "user" };
    }

    [Fact(DisplayName = "CreateArtist()")]
    public void CreateArtist_ProvideValidData_FactoryShouldCreateNewArtistModel()
    {
        // Arrange:
        var modelFactory = new ModelFactory();

        // Act:
        var sut = modelFactory.CreateArtist(
            genreId: Guid.NewGuid(),
            name: _faker.Random.Word());

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<Artist>();
    }

    [Fact(DisplayName = "CreateGenre()")]
    public void CreateGenre_ProvideValidData_FactoryShouldCreateNewGenreModel()
    {
        // Arrange:
        var modelFactory = new ModelFactory();

        // Act:
        var sut = modelFactory.CreateGenre(name: _faker.Random.Word());

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<Genre>();
    }

    [Fact(DisplayName = "CreateProduction()")]
    public void CreateProduction_ProvideValidData_FactoryShouldCreateNewProductionModel()
    {
        // Arrange:
        var modelFactory = new ModelFactory();

        // Act:
        var sut = modelFactory.CreateProduction(
            artistId: Guid.NewGuid(),
            title: _faker.Random.Word(),
            category: _faker.PickRandom<Category>(),
            releaseDate: DateTime.UtcNow.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<Production>();
    }

    [Fact(DisplayName = "CreateTrack()")]
    public void CreateTrack_ProvideValidData_FactoryShouldCreateNewTrackModel()
    {
        // Arrange:
        var modelFactory = new ModelFactory();

        // Act:
        var sut = modelFactory.CreateTrack(
            productionId: Guid.NewGuid(),
            position: _faker.Random.Byte(),
            title: _faker.Random.Word(),
            length: _faker.Random.Float());

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<Track>();
    }

    [Fact(DisplayName = "CreateUser()")]
    public void CreateUser_ProvideValidData_FactoryShouldCreateNewUserModel()
    {
        // Arrange:
        var modelFactory = new ModelFactory();

        // Act:
        var sut = modelFactory.CreateUser(
            username: _faker.Internet.UserName(),
            password: _faker.Hashids.Encode(),
            passwordSalt: _faker.Hashids.Encode(),
            role: _faker.PickRandom(_roles));

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<User>();
    }
}