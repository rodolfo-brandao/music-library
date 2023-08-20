using MusicLibrary.Core.Contracts.Repositories.Redis;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Core.Contracts.Repositories;

public interface IUserRepository : IRedisRepository<User>
{
}
