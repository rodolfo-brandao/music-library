using MusicLibrary.Core.Contracts.Factories;
using MusicLibrary.Core.Factories;
using MusicLibrary.Tests.Setup.Fakers.Models;

namespace MusicLibrary.Tests.Core.Models;

[Trait("Model", "User")]
public class UserTest
{
    private readonly IModelFactory _modelFactory;
    private readonly Faker _faker;
    private readonly string[] _roles;

    public UserTest()
    {
        _modelFactory = new ModelFactory();
        _faker = new Faker();
        _roles = new[] { "admin", "user" };
    }

    [Fact(DisplayName = "Change...()")]
    public void Change_EditNewGenre_ModelShouldUpdateProperties()
    {
        // Arrange:
        var user = _modelFactory.CreateUser(
            username: _faker.Internet.UserName(),
            password: _faker.Hashids.Encode(),
            passwordSalt: _faker.Hashids.Encode(),
            role: _faker.PickRandom(_roles));

        var anotherUser = UserModelFake.Valid();

        // Act:
        user.ChangeUsername(anotherUser.Username);
        user.ChangePassword(anotherUser.Password, anotherUser.PasswordSalt);
        user.ChangeRole(anotherUser.Role);

        // Assert:
        user.Username.Should().Be(anotherUser.Username);
        user.Password.Should().Be(anotherUser.Password);
        user.PasswordSalt.Should().Be(anotherUser.PasswordSalt);
        user.Role.Should().Be(anotherUser.Role);
    }
}