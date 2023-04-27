using MusicLibrary.Core.Enums;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Core.Factories;

public sealed class ModelFactory : IModelFactory
{
    public Artist CreateArtist(Guid genreId, string name) => new()
    {
        Id = Guid.NewGuid(),
        GenreId = genreId,
        Name = name,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = default,
        IsDisabled = default
    };

    public Genre CreateGenre(string name) => new()
    {
        Id = Guid.NewGuid(),
        Name = name,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = default,
        IsDisabled = default
    };

    public Music CreateMusic(Guid productionId, byte ordinalPosition, string title, float durationInMinutes) => new()
    {
        Id = Guid.NewGuid(),
        ProductionId = productionId,
        OrdinalPosition = ordinalPosition,
        Title = title,
        DurationInMinutes = durationInMinutes,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = default,
        IsDisabled = default
    };

    public Production CreateProduction(Guid artistId, string title, ProductionType productionType,
        ushort releaseYear) => new()
    {
        Id = Guid.NewGuid(),
        ArtistId = artistId,
        Title = title,
        ProductionType = productionType,
        ReleaseYear = releaseYear,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = default,
        IsDisabled = default
    };

    public User CreateUser(string username, string email, string password, string passwordSalt, string role) => new()
    {
        Id = Guid.NewGuid(),
        Username = username,
        Email = email,
        Password = password,
        PasswordSalt = passwordSalt,
        Role = role,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = default,
        IsDisabled = default
    };
}