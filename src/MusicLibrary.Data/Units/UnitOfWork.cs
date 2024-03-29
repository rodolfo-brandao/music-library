using MusicLibrary.Core.Contracts.Units;
using MusicLibrary.Data.DbContexts;

namespace MusicLibrary.Data.Units;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly MusicLibraryDbContext _musicLibraryDbContext;

    public UnitOfWork(MusicLibraryDbContext musicLibraryDbContext)
    {
        _musicLibraryDbContext = musicLibraryDbContext;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _musicLibraryDbContext.SaveChangesAsync();
    }
}