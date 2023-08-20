using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Models;
using MusicLibrary.Core.Models.Nulls;

namespace MusicLibrary.Tests.Setup.Builders.Repositories;

internal sealed class UserRepositoryMockBuilder
{
    private readonly Mock<IUserRepository> _mock;

    private UserRepositoryMockBuilder()
    {
        _mock = new Mock<IUserRepository>();
    }

    public IUserRepository Build() => _mock.Object;

    public static UserRepositoryMockBuilder Create() => new();

    public UserRepositoryMockBuilder SetupGetByKeyAsync(User userModelToBeReturned = default)
    {
        _mock.Setup(userRepository => userRepository.GetByKeyAsync(It.IsAny<string>()))
            .ReturnsAsync(userModelToBeReturned ?? new NullUser());
        return this;
    }
}