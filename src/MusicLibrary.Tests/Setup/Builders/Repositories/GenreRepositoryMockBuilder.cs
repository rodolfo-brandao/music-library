using System.Linq.Expressions;
using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Tests.Setup.Builders.Repositories;

internal sealed class GenreRepositoryMockBuilder
{
    private readonly Mock<IGenreRepository> _mock;

    public GenreRepositoryMockBuilder()
    {
        _mock = new Mock<IGenreRepository>();
    }

    public IGenreRepository Build() => _mock.Object;

    public static GenreRepositoryMockBuilder Create() => new();

    public GenreRepositoryMockBuilder SetupQuery(params Genre[] genres)
    {
        _mock.Setup(genreRepository =>
                genreRepository.Query(It.IsAny<Expression<Func<Genre, bool>>>(), It.IsAny<string>(), It.IsAny<bool>()))
            .Returns(genres.AsQueryable());
        return this;
    }
}