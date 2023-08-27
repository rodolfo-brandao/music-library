using System.Linq.Expressions;
using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Models;
using MusicLibrary.Tests.Setup.Fakers.Models;

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

    /// <summary>
    /// Mocks the ExistsAsync() method.
    /// </summary>
    /// <param name="exists">Indicates whether the model in question should exist.</param>
    public GenreRepositoryMockBuilder SetupExistsAsync(bool exists = default)
    {
        _mock.Setup(genreRepository => genreRepository.ExistsAsync(It.IsAny<Expression<Func<Genre, bool>>>()))
            .ReturnsAsync(exists);
        return this;
    }

    /// <summary>
    /// Mocks the InsertAsync() method.
    /// </summary>
    /// <param name="genre">The model to be returned by the mocked method (optional).</param>
    public GenreRepositoryMockBuilder SetupInsertAsync(Genre genre = default)
    {
        _mock.Setup(genreRepository => genreRepository.InsertAsync(It.IsAny<Genre>()))
            .ReturnsAsync(genre ?? GenreModelFake.Valid);
        return this;
    }

    /// <summary>
    /// Mocks the Query() method.
    /// </summary>
    /// <param name="genres">The array of models the be returned by the mocked method.</param>
    public GenreRepositoryMockBuilder SetupQuery(params Genre[] genres)
    {
        _mock.Setup(genreRepository =>
                genreRepository.Query(It.IsAny<Expression<Func<Genre, bool>>>(), It.IsAny<string>(), It.IsAny<bool>()))
            .Returns(genres.AsQueryable());
        return this;
    }
}