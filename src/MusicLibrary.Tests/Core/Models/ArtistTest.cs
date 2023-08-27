using MusicLibrary.Core.Contracts.Factories;
using MusicLibrary.Core.Factories;
using MusicLibrary.Tests.Setup.Fakers.Models;

namespace MusicLibrary.Tests.Core.Models;

[Trait("Model", "Artist")]
public class ArtistTest
{
    private readonly IModelFactory _modelFactory;
    private readonly Faker _faker;

    public ArtistTest()
    {
        _modelFactory = new ModelFactory();
        _faker = new Faker();
    }

    [Fact(DisplayName = "Change...()")]
    public void Change_EditNewArtist_ModelShouldUpdateProperties()
    {
        // Arrange:
        var artist = _modelFactory.CreateArtist(
            genreId: Guid.NewGuid(),
            name: _faker.Random.Word());

        var anotherArtist = ArtistModelFake.Valid;

        // Act:
        artist.ChangeGenre(anotherArtist.GenreId);
        artist.ChangeName(anotherArtist.Name);

        // Assert:
        artist.GenreId.Should().Be(anotherArtist.GenreId);
        artist.Name.Should().Be(anotherArtist.Name);
    }
}