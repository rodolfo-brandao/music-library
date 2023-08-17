using MusicLibrary.Application.Utils;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Tests.Setup.Fakers.Models
{
    internal static class UserModelFake
    {
        private static string[] Roles => new string[]
        {
            AuthorizationRoles.Admin,
            AuthorizationRoles.User
        };

        public static User Valid(string username = default) => new Faker<User>()
            .RuleFor(user => user.Id, _ => Guid.NewGuid())
            .RuleFor(user => user.Username, faker => username ?? faker.Internet.UserName())
            .RuleFor(user => user.Email, faker => faker.Internet.Email())
            .RuleFor(user => user.Password, faker => faker.Hashids.Encode())
            .RuleFor(user => user.PasswordSalt, faker => faker.Hashids.Encode())
            .RuleFor(user => user.Role, faker => faker.PickRandom(Roles))
            .RuleFor(user => user.CreatedAt, _ => DateTime.UtcNow)
            .RuleFor(user => user.UpdatedAt, _ => default)
            .RuleFor(user => user.IsDisabled, _ => default)
            .Generate();
    }
}