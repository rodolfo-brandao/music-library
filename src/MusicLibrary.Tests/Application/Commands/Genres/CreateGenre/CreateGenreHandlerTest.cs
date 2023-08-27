using System.Collections;
using MusicLibrary.Application.Commands.Genres.CreateGenre;
using MusicLibrary.Application.Responses.Genres;
using MusicLibrary.Application.Utils;
using MusicLibrary.Tests.Setup.Builders.Factories;
using MusicLibrary.Tests.Setup.Builders.Repositories;
using MusicLibrary.Tests.Setup.Builders.UnitsOfWork;
using MusicLibrary.Tests.Setup.Fakers.Commands.Genres.CreateGenre;
using Serilog;

namespace MusicLibrary.Tests.Application.Commands.Genres.CreateGenre;

[Trait("Handler", "CreateGenre")]
public class CreateGenreHandlerTest
{
    private readonly ILogger _logger;

    public CreateGenreHandlerTest()
    {
        _logger = new Mock<ILogger>().Object;
    }

    [Fact(DisplayName = "[async] Handle() - Success Case")]
    public async Task Handle_PassValidCommandObject_HandlerShouldCreateNewGenre()
    {
        // Arrange:
        var command = CreateGenreCommandFake.Valid();

        var genreRepository = GenreRepositoryMockBuilder
            .Create()
            .SetupExistsAsync()
            .SetupInsertAsync()
            .Build();

        var modelFactory = ModelFactoryMockBuilder
            .Create()
            .SetupCreateGenre()
            .Build();

        var unitOfWork = UnitOfWorkMockBuilder
            .Create()
            .SetupSaveChangesAsync()
            .Build();

        var handler = new CreateGenreHandler(genreRepository, modelFactory, unitOfWork, _logger);

        // Act:
        var sut = await handler.Handle(command, cancellationToken: default);

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<ApiResult<CreatedGenreResponse>>();
        sut.Response.Should().NotBeNull();
        sut.ErrorMessage.Should().BeNull();
    }

    [Fact(DisplayName = "[async] Handle() - Failure Case: genre already exists for given name")]
    public async Task Handle_GenreAlreadyExistsWithName_HandlerShouldNotCreateGenre()
    {
        // Arrange:
        var command = CreateGenreCommandFake.Valid();

        var genreRepository = GenreRepositoryMockBuilder
            .Create()
            .SetupExistsAsync(exists: true)
            .SetupInsertAsync()
            .Build();

        var modelFactory = ModelFactoryMockBuilder
            .Create()
            .SetupCreateGenre()
            .Build();

        var unitOfWork = UnitOfWorkMockBuilder
            .Create()
            .SetupSaveChangesAsync()
            .Build();

        var handler = new CreateGenreHandler(genreRepository, modelFactory, unitOfWork, _logger);

        // Act:
        var sut = await handler.Handle(command, cancellationToken: default);

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<ApiResult<CreatedGenreResponse>>();
        sut.Response.Should().BeNull();
        sut.ErrorMessage.Should().NotBeNullOrWhiteSpace();
    }

    [Theory(DisplayName = "[async] Handle() - Failure Cases (2): command object with invalid 'Name' property value")]
    [ClassData(typeof(CreateGenreInvalidCommands))]
    public async Task Handle_PassInvalidCommandObject_HandlerShouldNotCreateGenre(CreateGenreCommand command)
    {
        // Arrange:
        var genreRepository = GenreRepositoryMockBuilder
            .Create()
            .SetupExistsAsync()
            .SetupInsertAsync()
            .Build();

        var modelFactory = ModelFactoryMockBuilder
            .Create()
            .SetupCreateGenre()
            .Build();

        var unitOfWork = UnitOfWorkMockBuilder
            .Create()
            .SetupSaveChangesAsync()
            .Build();

        var handler = new CreateGenreHandler(genreRepository, modelFactory, unitOfWork, _logger);

        // Act:
        var sut = await handler.Handle(command, cancellationToken: default);

        // Assert:
        sut.Should().NotBeNull().And.BeOfType<ApiResult<CreatedGenreResponse>>();
        sut.Response.Should().BeNull();
        sut.ErrorMessage.Should().NotBeNullOrWhiteSpace();
    }
}

/// <summary>
/// Utility class to provide invalid command objects in test methods.
/// </summary>
internal class CreateGenreInvalidCommands : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            CreateGenreCommandFake.WithNullName
        };

        yield return new object[]
        {
            CreateGenreCommandFake.WithNameLengthExceeded
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}