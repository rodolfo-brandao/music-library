namespace MusicLibrary.Core.Contracts.Units;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
