namespace MusicLibrary.Core.Contracts.Unities;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}