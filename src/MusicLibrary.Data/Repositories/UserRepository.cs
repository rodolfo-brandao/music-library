using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Models;
using MusicLibrary.Data.Repositories.Redis;
using StackExchange.Redis;

namespace MusicLibrary.Data.Repositories;

public class UserRepository : RedisRepository<User>, IUserRepository
{
    public UserRepository(IConnectionMultiplexer connectionMultiplexer) : base(connectionMultiplexer)
    {
    }
}