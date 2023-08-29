using Microsoft.Extensions.Configuration;
using MusicLibrary.Tests.Setup.Builders.Abstract;

namespace MusicLibrary.Tests.Setup.Builders.Microsoft.Extensions.Configuration;

internal class ConfigurationMockBuilder : BaseMockBuilder<ConfigurationMockBuilder, IConfiguration>
{
    /// <summary>
    /// Mocks the GetSection() method.
    /// </summary>
    /// <param name="value">The value to be returned in the given section.</param>
    public ConfigurationMockBuilder SetupGetSection(object value)
    {
        var configurationSectionMock = new Mock<IConfigurationSection>();
        configurationSectionMock.Setup(configurationSection => configurationSection.Value)
            .Returns(value.ToString());

        Mock.Setup(configuration => configuration.GetSection(It.IsAny<string>()))
            .Returns(configurationSectionMock.Object);
        return this;
    }
}