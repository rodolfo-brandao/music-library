using MusicLibrary.Core.Models;

namespace MusicLibrary.Core.Contracts.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByUsername(string username, bool isReadOnly = default);
}