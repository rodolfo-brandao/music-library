using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Models;
using MusicLibrary.Data.DbContexts;

namespace MusicLibrary.Data.Repositories;

public class GenreRepository : Repository<Genre>, IGenreRepository
{
    public GenreRepository(MusicLibraryDbContext musicLibraryDbContext) : base(musicLibraryDbContext)
    {
    }
}