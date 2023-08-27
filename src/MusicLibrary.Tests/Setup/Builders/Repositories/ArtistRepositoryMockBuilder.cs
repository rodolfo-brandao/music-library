using System.Linq.Expressions;
using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Tests.Setup.Builders.Repositories;

internal sealed class ArtistRepositoryMockBuilder
{
    private readonly Mock<IArtistRepository> _mock;

    private ArtistRepositoryMockBuilder()
    {
        _mock = new Mock<IArtistRepository>();
    }

    public IArtistRepository Build() => _mock.Object;

    public static ArtistRepositoryMockBuilder Create() => new();

    /// <summary>
    /// Mocks the Query() method.
    /// </summary>
    /// <param name="artists">The array of models the be returned by the mocked method.</param>
    public ArtistRepositoryMockBuilder SetupQuery(params Artist[] artists)
    {
        _mock.Setup(artistRepository => artistRepository.Query(It.IsAny<Expression<Func<Artist, bool>>>(), It.IsAny<string>(), It.IsAny<bool>()))
            .Returns(artists.AsQueryable());
        return this;
    }
}