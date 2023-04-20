using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Models;
using MusicLibrary.Data.Context;

namespace MusicLibrary.Data.Repositories;

public class MusicRepository : Repository<Music>, IMusicRepository
{
    public MusicRepository(MusicLibraryDbContext musicLibraryDbContext) : base(musicLibraryDbContext)
    {
    }
}