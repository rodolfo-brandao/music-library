using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Models.Abstract;
using MusicLibrary.Data.DbContexts;

namespace MusicLibrary.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly DbSet<TEntity> _dbSet;

    public Repository(MusicLibraryDbContext musicLibraryDbContext)
    {
        _dbSet = musicLibraryDbContext.Set<TEntity>();
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await Query(expression, isReadOnly: true).AnyAsync();
    }

    public async Task<TEntity> GetByKeyAsync(params object[] keys)
    {
        return await _dbSet.FindAsync(keys);
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        return (await _dbSet.AddAsync(entity)).Entity;
    }

    public async Task InsertRangeAsync(params TEntity[] entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression, string includes = "",
        bool isReadOnly = default)
    {
        var query = isReadOnly ? _dbSet.AsNoTracking() : _dbSet;

        foreach (var included in includes.Split(',', StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(included);
        }

        return query.Where(expression ?? (_ => true));
    }

    public TEntity Remove(TEntity entity)
    {
        return _dbSet.Remove(entity).Entity;
    }

    public void RemoveRange(params TEntity[] entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public TEntity Update(TEntity entity)
    {
        return _dbSet.Update(entity).Entity;
    }

    public void UpdateRange(params TEntity[] entities)
    {
        _dbSet.UpdateRange(entities);
    }
}