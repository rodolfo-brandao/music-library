using MusicLibrary.Core.Factories;
using MusicLibrary.Tests.Setup.Fakers.Models;

namespace MusicLibrary.Tests.Core.Models;

[Trait("Model", "Genre")]
public class GenreTest
{
    private readonly IModelFactory _modelFactory;
    private readonly Faker _faker;

    public GenreTest()
    {
        _modelFactory = new ModelFactory();
        _faker = new Faker();
    }

    [Fact(DisplayName = "Change...()")]
    public void Change_EditNewGenre_ModelShouldUpdateProperties()
    {
        // Arrange:
        var genre = _modelFactory.CreateGenre(name: _faker.Random.Word());
        var anotherGenre = GenreModelFake.Valid;

        // Act:
        genre.ChangeName(anotherGenre.Name);

        // Assert:
        genre.Name.Should().Be(anotherGenre.Name);
    }
}