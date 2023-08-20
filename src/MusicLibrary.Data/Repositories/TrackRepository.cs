using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Models;
using MusicLibrary.Data.Context;

namespace MusicLibrary.Data.Repositories;

public class TrackRepository : Repository<Track>, ITrackRepository
{
    public TrackRepository(MusicLibraryDbContext musicLibraryDbContext) : base(musicLibraryDbContext)
    {
    }
}