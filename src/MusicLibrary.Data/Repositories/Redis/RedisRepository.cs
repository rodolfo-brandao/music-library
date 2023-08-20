using MusicLibrary.Core.Contracts.Repositories.Redis;
using MusicLibrary.Core.Models.Abstract;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MusicLibrary.Data.Repositories.Redis;

public class RedisRepository<TEntity> : IRedisRepository<TEntity> where TEntity : Entity
{
    private readonly IDatabase _database;

    public RedisRepository(IConnectionMultiplexer connectionMultiplexer)
    {
        _database = connectionMultiplexer.GetDatabase();
    }

    public async Task<TEntity> GetByKeyAsync(string key)
    {
        var record = (await _database.StringGetAsync(new RedisKey(key))).ToString();
        return !string.IsNullOrWhiteSpace(record) ? JsonConvert.DeserializeObject<TEntity>(record) : default;
    }

    public async Task<bool> InsertAsync(string key, TEntity entity)
        => await _database.StringSetAsync(new RedisKey(key), JsonConvert.SerializeObject(entity));

    public async Task<bool> RemoveAsync(string key)
        => await _database.KeyDeleteAsync(new RedisKey(key));
}