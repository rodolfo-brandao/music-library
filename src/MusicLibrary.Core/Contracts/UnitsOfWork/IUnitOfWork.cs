namespace MusicLibrary.Core.Contracts.UnitsOfWork;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}