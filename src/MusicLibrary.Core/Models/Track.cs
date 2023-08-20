using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models;

public class Track : TrackableEntity
{
    public virtual Guid ProductionId { get; protected internal set; }
    public virtual byte Position { get; protected internal set; }
    public virtual string Title { get; protected internal set; }
    public virtual float Length { get; protected internal set; }

    #region Navigation properties

    public Production Production { get; protected set; }

    #endregion

    public virtual Track ChangeProduction(Guid productionId)
    {
        ProductionId = productionId;
        return this;
    }

    public virtual Track ChangePosition(byte position)
    {
        Position = position;
        return this;
    }

    public virtual Track ChangeTitle(string title)
    {
        Title = title;
        return this;
    }

    public virtual Track ChangeLength(float length)
    {
        Length = length;
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