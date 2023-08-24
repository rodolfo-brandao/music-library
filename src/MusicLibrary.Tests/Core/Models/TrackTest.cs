using MusicLibrary.Core.Factories;
using MusicLibrary.Tests.Setup.Fakers.Models;

namespace MusicLibrary.Tests.Core.Models;

[Trait("Model", "Track")]
public class TrackTest
{
    private readonly IModelFactory _modelFactory;
    private readonly Faker _faker;

    public TrackTest()
    {
        _modelFactory = new ModelFactory();
        _faker = new Faker();
    }

    [Fact(DisplayName = "Change...()")]
    public void Change_EditNewGenre_ModelShouldUpdateProperties()
    {
        // Arrange:
        var track = _modelFactory.CreateTrack(
            productionId: Guid.NewGuid(),
            position: _faker.Random.Byte(),
            title: _faker.Random.Word(),
            length: _faker.Random.Float());

        var anotherTrack = TrackModelFake.Valid;

        // Act:
        track.ChangeProduction(anotherTrack.ProductionId);
        track.ChangePosition(anotherTrack.Position);
        track.ChangeTitle(anotherTrack.Title);
        track.ChangeLength(anotherTrack.Length);

        // Assert:
        track.ProductionId.Should().Be(anotherTrack.ProductionId);
        track.Position.Should().Be(anotherTrack.Position);
        track.Title.Should().Be(anotherTrack.Title);
        track.Length.Should().Be(anotherTrack.Length);
    }
}