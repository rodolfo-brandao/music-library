using MusicLibrary.Tests.Setup.Builders.Abstract;
using StackExchange.Redis;

namespace MusicLibrary.Tests.Setup.Builders.StackExchange.Redis;

internal sealed class ConnectionMultiplexerMockBuilder
    : BaseMockBuilder<ConnectionMultiplexerMockBuilder, IConnectionMultiplexer>
{
}