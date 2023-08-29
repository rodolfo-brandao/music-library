namespace MusicLibrary.Tests.Setup.Builders.Abstract;

/// <summary>
/// Basic abstraction that provides the methods for creating and building mock builders.
/// </summary>
/// <typeparam name="TMockBuilder">The reference type that will inherit this abstraction and have its implementations.</typeparam>
/// <typeparam name="TMockTarget">The reference type for builders to mock.</typeparam>
internal abstract class BaseMockBuilder<TMockBuilder, TMockTarget>
    where TMockBuilder : class, new()
    where TMockTarget : class
{
    protected readonly Mock<TMockTarget> Mock = new();

    public TMockTarget Build() => Mock.Object;

    public static TMockBuilder Create() => new();
}