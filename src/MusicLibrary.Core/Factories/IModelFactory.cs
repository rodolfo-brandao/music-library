using MusicLibrary.Core.Enums;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Core.Factories;

public interface IModelFactory
{
    Artist CreateArtist(Guid genreId, string name);
    Genre CreateGenre(string name);
    Production CreateProduction(Guid artistId, string title, ProductionType productionType, string releaseDate);
    Track CreateTrack(Guid productionId, byte ordinalPosition, string title, float length);
    User CreateUser(string username, string password, string passwordSalt, string role);
}