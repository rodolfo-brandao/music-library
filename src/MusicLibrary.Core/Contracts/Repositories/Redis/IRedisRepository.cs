using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Contracts.Repositories.Redis;

public interface IRedisRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> GetByKeyAsync(string key);
    Task<bool> InsertAsync(string key, TEntity entity);
    Task<bool> RemoveAsync(string key);
}