using System.Linq.Expressions;
using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Models;
using MusicLibrary.Tests.Setup.Builders.Abstract;

namespace MusicLibrary.Tests.Setup.Builders.Repositories;

internal sealed class ArtistRepositoryMockBuilder : BaseMockBuilder<ArtistRepositoryMockBuilder, IArtistRepository>
{
    /// <summary>
    /// Mocks the Query() method.
    /// </summary>
    /// <param name="artists">The array of models the be returned by the mocked method.</param>
    public ArtistRepositoryMockBuilder SetupQuery(params Artist[] artists)
    {
        Mock.Setup(artistRepository =>
                artistRepository.Query(It.IsAny<Expression<Func<Artist, bool>>>(), It.IsAny<string>(),
                    It.IsAny<bool>()))
            .Returns(artists.AsQueryable());
        return this;
    }
}