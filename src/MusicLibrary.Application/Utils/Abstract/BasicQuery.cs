namespace MusicLibrary.Application.Utils.Abstract;

/// <summary>
/// Simple abstraction to provide common query properties.
/// </summary>
public abstract class BasicQuery
{
    public string Name { get; init; } = default;

    public string OrderBy { get; init; } = "asc";
}