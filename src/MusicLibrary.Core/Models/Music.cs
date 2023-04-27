using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models;

public class Music : TrackableEntity
{
    public virtual Guid ProductionId { get; protected internal set; }
    public virtual byte OrdinalPosition { get; protected internal set; }
    public virtual string Title { get; protected internal set; }
    public virtual float DurationInMinutes { get; protected internal set; }

    #region Navigation properties

    public Production Production { get; protected set; }

    #endregion

    public virtual Music ChangeProduction(Guid productionId)
    {
        ProductionId = productionId;
        return this;
    }

    public virtual Music ChangeOrdinalPosition(byte ordinalPosition)
    {
        OrdinalPosition = ordinalPosition;
        return this;
    }

    public virtual Music ChangeTitle(string title)
    {
        Title = title;
        return this;
    }

    public virtual Music ChangeDuration(float durationInMinutes)
    {
        DurationInMinutes = durationInMinutes;
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