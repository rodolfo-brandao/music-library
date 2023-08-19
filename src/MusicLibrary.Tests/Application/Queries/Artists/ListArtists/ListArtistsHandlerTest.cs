using MusicLibrary.Application.Queries.Artists.ListArtists;
using MusicLibrary.Application.Responses.Artists;
using MusicLibrary.Application.Utils;
using MusicLibrary.Tests.Setup.Builders.Repositories;
using MusicLibrary.Tests.Setup.Fakers.Models;

namespace MusicLibrary.Tests.Application.Queries.Artists.ListArtists;

[Trait("Handler", "ListArtists")]
public class ListArtistsHandlerTest
{
    [Fact(DisplayName = "Handle() - Success Case")]
    public async Task Handle_PassValidQueryObject_HandlerShouldListArtists()
    {
        // Arrange:
        var artists = Enumerable
            .Range(start: default, count: 5)
            .Select(_ => ArtistModelFake.Valid)
            .ToArray();

        var query = new ListArtistsQuery
        {
            Name = artists.First().Name
        };

        var artistRepository = ArtistRepositoryMockBuilder
            .Create()
            .SetupQuery(artists)
            .Build();

        var handler = new ListArtistsHandler(artistRepository);

        // Act:
        var sut = await handler.Handle(query, cancellationToken: default);

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<ApiResult<IEnumerable<DefaultArtistResponse>>>();
        sut.Response.Should().NotBeNullOrEmpty();
        sut.ErrorMessage.Should().BeNull();
    }

    [Fact(DisplayName = "Handle() - Failure Case: query object with invalid 'OrderBy' param value")]
    public async Task Handle_PassInvalidQueryObject_HandlerShouldNotListArtists()
    {
        // Arrange:
        var invalidQuery = new ListArtistsQuery
        {
            Name = default,
            OrderBy = new Faker().Random.Word()
        };

        var artists = Enumerable
            .Range(start: default, count: 5)
            .Select(_ => ArtistModelFake.Valid)
            .ToArray();

        var artistRepository = ArtistRepositoryMockBuilder
            .Create()
            .SetupQuery(artists)
            .Build();

        var handler = new ListArtistsHandler(artistRepository);

        // Act:
        var sut = await handler.Handle(invalidQuery, cancellationToken: default);

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<ApiResult<IEnumerable<DefaultArtistResponse>>>();
        sut.Response.Should().BeNull();
        sut.ErrorMessage.Should().NotBeNullOrWhiteSpace();
    }
}