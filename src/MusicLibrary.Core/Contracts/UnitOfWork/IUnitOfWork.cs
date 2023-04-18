namespace MusicLibrary.Core.Contracts.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}