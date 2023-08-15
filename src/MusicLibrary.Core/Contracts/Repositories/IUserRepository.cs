using MusicLibrary.Core.Models;

namespace MusicLibrary.Core.Contracts.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByUsernameAsync(string username, bool isReadOnly = default);
}
