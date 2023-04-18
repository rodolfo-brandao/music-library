using System.Linq.Expressions;
using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Contracts.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> GetByKeyAsync(params object[] keys);
    Task<TEntity> InsertAsync(TEntity entity);
    Task InsertRangeAsync(params TEntity[] entities);

    IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression, string includes = "",
        bool isReadOnly = default);

    TEntity Remove(TEntity entity);
    void RemoveRange(params TEntity[] entities);
    TEntity Update(TEntity entity);
    void UpdateRange(params TEntity[] entities);
}