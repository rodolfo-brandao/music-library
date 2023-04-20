using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Models;
using MusicLibrary.Data.Context;

namespace MusicLibrary.Data.Repositories;

public class ArtistRepository : Repository<Artist>, IArtistRepository
{
    public ArtistRepository(MusicLibraryDbContext musicLibraryDbContext) : base(musicLibraryDbContext)
    {
    }
}