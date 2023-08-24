using MusicLibrary.Core.Enums;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Core.Factories;

/// <summary>
/// A factory abstraction for a component that can create model instances.
/// </summary>
public interface IModelFactory
{
    Artist CreateArtist(Guid genreId, string name);
    Genre CreateGenre(string name);
    Production CreateProduction(Guid artistId, string title, Category category, string releaseDate);
    Track CreateTrack(Guid productionId, byte position, string title, float length);
    User CreateUser(string username, string password, string passwordSalt, string role);
}