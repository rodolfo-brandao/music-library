using MusicLibrary.Core.Contracts.Services;
using MusicLibrary.Core.Models;
using MusicLibrary.Core.Models.Nulls;
using MusicLibrary.Tests.Setup.Builders.Abstract;

namespace MusicLibrary.Tests.Setup.Builders.Services;

internal sealed class SecurityServiceMockBuilder : BaseMockBuilder<SecurityServiceMockBuilder, ISecurityService>
{
    /// <summary>
    /// Mocks the CreateUserAccessToken() method.
    /// </summary>
    public SecurityServiceMockBuilder SetupCreateUserAccessToken()
    {
        Mock.Setup(securityService => securityService.CreateUserAccessToken(It.IsAny<User>()))
            .Returns(string.Empty);
        return this;
    }

    /// <summary>
    /// Mocks the GetUserAsync() method.
    /// </summary>
    /// <param name="user">The model to be returned by the mocked method (optional).</param>
    public SecurityServiceMockBuilder SetupGetUserAsync(User user = default)
    {
        Mock.Setup(securityService => securityService.GetUserAsync(It.IsAny<string>()))
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
        Mock.Setup(securityService =>
                securityService.ValidatePassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Returns(passwordIsValid);
        return this;
    }
}