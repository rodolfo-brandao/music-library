using MusicLibrary.Core.Contracts.Factories;
using MusicLibrary.Core.Enums;
using MusicLibrary.Core.Factories;
using MusicLibrary.Core.Models;
using MusicLibrary.Tests.Setup.Builders.Abstract;
using MusicLibrary.Tests.Setup.Fakers.Models;

namespace MusicLibrary.Tests.Setup.Builders.Factories;

internal sealed class ModelFactoryMockBuilder : BaseMockBuilder<ModelFactoryMockBuilder, IModelFactory>
{
    /// <summary>
    /// Mocks the CreateArtist() method.
    /// </summary>
    /// <param name="artist">The model to be returned by the mocked method (optional).</param>
    public ModelFactoryMockBuilder SetupCreateArtist(Artist artist = default)
    {
        Mock.Setup(modelFactory => modelFactory.CreateArtist(It.IsAny<Guid>(), It.IsAny<string>()))
            .Returns(artist ?? ArtistModelFake.Valid);
        return this;
    }

    /// <summary>
    /// Mocks the CreateGenre() method.
    /// </summary>
    /// <param name="genre">The model to be returned by the mocked method (optional).</param>
    public ModelFactoryMockBuilder SetupCreateGenre(Genre genre = default)
    {
        Mock.Setup(modelFactory => modelFactory.CreateGenre(It.IsAny<string>()))
            .Returns(genre ?? GenreModelFake.Valid);
        return this;
    }

    /// <summary>
    /// Mocks the CreateProduction() method.
    /// </summary>
    /// <param name="production">The model to be returned by the mocked method (optional).</param>
    public ModelFactoryMockBuilder SetupCreateProduction(Production production = default)
    {
        Mock.Setup(modelFactory =>
                modelFactory.CreateProduction(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<Category>(),
                    It.IsAny<string>()))
            .Returns(production ?? ProductionModelFake.Valid);
        return this;
    }

    /// <summary>
    /// Mocks the CreateTrack() method.
    /// </summary>
    /// <param name="track">The model to be returned by the mocked method (optional).</param>
    public ModelFactoryMockBuilder SetupCreateTrack(Track track = default)
    {
        Mock.Setup(modelFactory =>
                modelFactory.CreateTrack(It.IsAny<Guid>(), It.IsAny<byte>(), It.IsAny<string>(), It.IsAny<float>()))
            .Returns(track ?? TrackModelFake.Valid);
        return this;
    }

    /// <summary>
    /// Mocks the CreateUser() method.
    /// </summary>
    /// <param name="user">The model to be returned by the mocked method (optional).</param>
    public ModelFactoryMockBuilder SetupCreateUser(User user = default)
    {
        Mock.Setup(modelFactory =>
                modelFactory.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Returns(user ?? UserModelFake.Valid());
        return this;
    }
}