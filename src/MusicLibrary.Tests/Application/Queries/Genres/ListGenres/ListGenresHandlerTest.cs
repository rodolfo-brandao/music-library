using MusicLibrary.Application.Queries.Genres.ListGenres;
using MusicLibrary.Application.Responses.Genres;
using MusicLibrary.Application.Utils;
using MusicLibrary.Tests.Setup.Builders.Repositories;
using MusicLibrary.Tests.Setup.Fakers.Models;

namespace MusicLibrary.Tests.Application.Queries.Genres.ListGenres;

[Trait("Handler", "ListGenres")]
public class ListGenresHandlerTest
{
    [Fact(DisplayName = "[async] Handle() - Success Case")]
    public async Task Handle_PassValidQueryObject_HandlerShouldListGenres()
    {
        // Arrange:
        var genres = Enumerable
            .Range(start: default, count: 5)
            .Select(_ => GenreModelFake.Valid)
            .ToArray();

        var query = new ListGenreQuery
        {
            Name = genres.First().Name
        };

        var genreRepository = GenreRepositoryMockBuilder
            .Create()
            .SetupQuery(genres)
            .Build();

        var handler = new ListGenresHandler(genreRepository);

        // Act:
        var sut = await handler.Handle(query, cancellationToken: default);

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<ApiResult<IEnumerable<DefaultGenreResponse>>>();
        sut.Response.Should().NotBeNullOrEmpty();
        sut.ErrorMessage.Should().BeNull();
    }

    [Fact(DisplayName = "[async] Handle() - Failure Case: query object with invalid 'OrderBy' param value")]
    public async Task Handle_PassInvalidQueryObject_HandlerShouldNotListArtists()
    {
        // Arrange:
        var invalidQuery = new ListGenreQuery
        {
            Name = default,
            OrderBy = new Faker().Random.Word()
        };

        var genres = Enumerable
            .Range(start: default, count: 5)
            .Select(_ => GenreModelFake.Valid)
            .ToArray();

        var genreRepository = GenreRepositoryMockBuilder
            .Create()
            .SetupQuery(genres)
            .Build();

        var handler = new ListGenresHandler(genreRepository);

        // Act:
        var sut = await handler.Handle(invalidQuery, cancellationToken: default);

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<ApiResult<IEnumerable<DefaultGenreResponse>>>();
        sut.Response.Should().BeNull();
        sut.ErrorMessage.Should().NotBeNullOrWhiteSpace();
    }
}