using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models;

public class Genre : TrackableEntity
{
    public virtual string Name { get; protected internal set; }

    #region Navigation properties

    public ICollection<Artist> Artists { get; protected set; } = new List<Artist>();

    #endregion

    public virtual Genre ChangeName(string name)
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
        UpdatedOn = DateTime.UtcNow;
        return this;
    }
}