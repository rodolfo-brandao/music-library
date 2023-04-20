using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Models;
using MusicLibrary.Data.Context;

namespace MusicLibrary.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(MusicLibraryDbContext musicLibraryDbContext) : base(musicLibraryDbContext)
    {
    }
}