using Microsoft.EntityFrameworkCore;
using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Models;
using MusicLibrary.Core.Models.Nulls;
using MusicLibrary.Data.Context;

namespace MusicLibrary.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(MusicLibraryDbContext musicLibraryDbContext) : base(musicLibraryDbContext)
    {
    }

    public async Task<User> GetByUsernameAsync(string username, bool isReadOnly = default)
    {
        return await Query(user => user.Username.Equals(username), isReadOnly: isReadOnly).FirstOrDefaultAsync() ??
               new NullUser();
    }
}