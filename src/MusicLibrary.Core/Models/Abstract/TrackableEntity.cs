namespace MusicLibrary.Core.Models.Abstract;

public abstract class TrackableEntity : Entity
{
    public DateTime CreatedAt { get; protected internal set; }
    public DateTime? UpdatedAt { get; protected internal set; }
    public bool IsDisabled { get; protected internal set; }

    public abstract TrackableEntity Disable();
    public abstract TrackableEntity Enable();
    public abstract TrackableEntity UpdateNow();
}