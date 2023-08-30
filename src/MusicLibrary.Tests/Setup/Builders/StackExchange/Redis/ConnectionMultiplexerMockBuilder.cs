using MusicLibrary.Tests.Setup.Builders.Abstract;
using StackExchange.Redis;

namespace MusicLibrary.Tests.Setup.Builders.StackExchange.Redis;

internal sealed class ConnectionMultiplexerMockBuilder
    : BaseMockBuilder<ConnectionMultiplexerMockBuilder, IConnectionMultiplexer>
{
    /// <summary>
    /// Mocks the GetDatabase() method.
    /// </summary>
    /// <param name="database">The Redis database instance.</param>
    public ConnectionMultiplexerMockBuilder SetupGetDatabase(IDatabase database)
    {
        Mock.Setup(connectionMultiplexer => connectionMultiplexer.GetDatabase(It.IsAny<int>(), It.IsAny<object>()))
            .Returns(database);
        return this;
    }
}