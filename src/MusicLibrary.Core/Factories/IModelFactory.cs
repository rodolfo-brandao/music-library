using MusicLibrary.Core.Enums;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Core.Factories;

public interface IModelFactory
{
    Artist CreateArtist(Guid genreId, string name);
    Genre CreateGenre(string name);
    Music CreateMusic(Guid productionId, byte ordinalPosition, string title, float durationInMinutes);
    Production CreateProduction(Guid artistId, string title, ProductionType productionType, ushort releaseYear);
    User CreateUser(string username, string email, string password, string passwordSalt, string role);
}