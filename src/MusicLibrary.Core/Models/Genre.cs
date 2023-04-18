using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models;

public class Genre : TrackableEntity
{
    public string Name { get; protected set; }

    public ICollection<Artist> Artists { get; protected set; } = new List<Artist>();

    public Genre(string name)
    {
        Id = new Guid();
        Name = name;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = default;
        IsDisabled = default;
    }

    public Genre ChangeName(string name)
    {
        Name = name;
        return this;
    }

    public override TrackableEntity Disable()
    {
        IsDisabled = true;
        return this;
    }

    public override TrackableEntity Enable()
    {
        IsDisabled = default;
        return this;
    }

    public override TrackableEntity UpdateNow()
    {
        UpdatedAt = DateTime.UtcNow;
        return this;
    }
}