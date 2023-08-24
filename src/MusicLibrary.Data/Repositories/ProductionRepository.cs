using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Models;
using MusicLibrary.Data.DbContexts;

namespace MusicLibrary.Data.Repositories;

public class ProductionRepository : Repository<Production>, IProductionRepository
{
    public ProductionRepository(MusicLibraryDbContext musicLibraryDbContext) : base(musicLibraryDbContext)
    {
    }
}