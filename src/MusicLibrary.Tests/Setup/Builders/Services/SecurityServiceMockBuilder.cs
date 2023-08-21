using MusicLibrary.Core.Contracts.Services;
using MusicLibrary.Core.Models;
using MusicLibrary.Core.Models.Nulls;

namespace MusicLibrary.Tests.Setup.Builders.Services
{
    internal sealed class SecurityServiceMockBuilder
    {
        private readonly Mock<ISecurityService> _mock;

        private SecurityServiceMockBuilder()
        {
            _mock = new Mock<ISecurityService>();
        }

        public ISecurityService Build() => _mock.Object;

        public static SecurityServiceMockBuilder Create() => new();

        public SecurityServiceMockBuilder SetupCreateUserAccessToken()
        {
            _mock.Setup(securityService => securityService.CreateUserAccessToken(It.IsAny<User>()))
                .Returns(string.Empty);
            return this;
        }

        public SecurityServiceMockBuilder SetupGetUserAsync(User userModelToBeReturned = default)
        {
            _mock.Setup(securityService => securityService.GetUserAsync(It.IsAny<string>()))
                .ReturnsAsync(userModelToBeReturned ?? new NullUser());
            return this;
        }

        public SecurityServiceMockBuilder SetupValidatePassword(bool passwordIsValid = default)
        {
            _mock.Setup(securityService =>
                    securityService.ValidatePassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(passwordIsValid);
            return this;
        }
    }
}