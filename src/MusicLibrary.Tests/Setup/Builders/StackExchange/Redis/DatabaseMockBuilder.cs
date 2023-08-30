using MusicLibrary.Core.Models;
using MusicLibrary.Tests.Setup.Builders.Abstract;
using MusicLibrary.Tests.Setup.Fakers.Models;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MusicLibrary.Tests.Setup.Builders.StackExchange.Redis;

internal class DatabaseMockBuilder : BaseMockBuilder<DatabaseMockBuilder, IDatabase>
{
    /// <summary>
    /// Mocks the StringSetAsync() method.
    /// </summary>
    /// <param name="stringWasSet">Indicates whenever the string was set or not (optional).</param>
    public DatabaseMockBuilder SetupStringSetAsync(bool stringWasSet = default)
    {
        Mock.Setup(database => database.StringSetAsync(
                It.IsAny<RedisKey>(),
                It.IsAny<RedisValue>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<bool>(),
                It.IsAny<When>(),
                It.IsAny<CommandFlags>()))
            .ReturnsAsync(stringWasSet);
        return this;
    }

    /// <summary>
    /// Mocks the StringGetAsync() method.
    /// </summary>
    /// <param name="key">The redis key name.</param>
    public DatabaseMockBuilder SetupStringGetAsync(string key)
    {
        var json = JsonConvert.SerializeObject(UserModelFake.Valid(username: key));
        Mock.Setup(database => database.StringGetAsync(It.IsAny<RedisKey>(), It.IsAny<CommandFlags>()))
            .ReturnsAsync(new RedisValue(json));
        return this;
    }

    /// <summary>
    /// Mocks the KeyDeleteAsync() method.
    /// </summary>
    /// <param name="keyWasDeleted">Indicates whenever the given key was deleted or not (optional).</param>
    public DatabaseMockBuilder SetupKeyDeleteAsync(bool keyWasDeleted = default)
    {
        Mock.Setup(database => database.KeyDeleteAsync(It.IsAny<RedisKey>(), It.IsAny<CommandFlags>()))
            .ReturnsAsync(keyWasDeleted);
        return this;
    }
}