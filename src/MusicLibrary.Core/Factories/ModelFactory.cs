using MusicLibrary.Core.Contracts.Factories;
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

    public Production CreateProduction(Guid artistId, string title, Category category,
        string releaseDate) => new()
    {
        Id = Guid.NewGuid(),
        ArtistId = artistId,
        Title = title,
        Category = category,
        ReleaseDate = releaseDate,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = default,
        IsDisabled = default
    };

    public Track CreateTrack(Guid productionId, byte position, string title, float length) => new()
    {
        Id = Guid.NewGuid(),
        ProductionId = productionId,
        Position = position,
        Title = title,
        Length = length,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = default,
        IsDisabled = default
    };

    public User CreateUser(string username, string password, string passwordSalt, string role) => new()
    {
        Id = Guid.NewGuid(),
        Username = username,
        Password = password,
        PasswordSalt = passwordSalt,
        Role = role,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = default,
        IsDisabled = default
    };
}