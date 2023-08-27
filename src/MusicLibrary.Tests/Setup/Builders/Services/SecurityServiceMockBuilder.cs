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

        /// <summary>
        /// Mocks the CreateUserAccessToken() method.
        /// </summary>
        public SecurityServiceMockBuilder SetupCreateUserAccessToken()
        {
            _mock.Setup(securityService => securityService.CreateUserAccessToken(It.IsAny<User>()))
                .Returns(string.Empty);
            return this;
        }

        /// <summary>
        /// Mocks the GetUserAsync() method.
        /// </summary>
        /// <param name="user">The model to be returned by the mocked method (optional).</param>
        public SecurityServiceMockBuilder SetupGetUserAsync(User user = default)
        {
            _mock.Setup(securityService => securityService.GetUserAsync(It.IsAny<string>()))
                .ReturnsAsync(user ?? new NullUser());
            return this;
        }

        /// <summary>
        /// Mocks the ValidatePassword() method.
        /// </summary>
        /// <param name="passwordIsValid">Indicates the return value of the mocked method.</param>
        /// <returns></returns>
        public SecurityServiceMockBuilder SetupValidatePassword(bool passwordIsValid = default)
        {
            _mock.Setup(securityService =>
                    securityService.ValidatePassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(passwordIsValid);
            return this;
        }
    }
}