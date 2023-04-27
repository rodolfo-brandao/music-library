using MusicLibrary.Core.Contracts.Unities;
using MusicLibrary.Data.Context;

namespace MusicLibrary.Data.Unities;

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