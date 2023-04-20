using MusicLibrary.Core.Contracts.UnitsOfWork;
using MusicLibrary.Data.Context;

namespace MusicLibrary.Data.UnitsOfWork;

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