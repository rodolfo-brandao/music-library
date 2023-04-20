using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models;

public class Music : TrackableEntity
{
    public Guid ProductionId { get; protected set; }
    public string Title { get; protected set; }
    public ushort DurationInMinutes { get; protected set; }

    #region Navigation properties

    public Production Production { get; protected set; }

    #endregion

    public Music(Guid productionId, string title, ushort durationInMinutes)
    {
        Id = new Guid();
        ProductionId = productionId;
        Title = title;
        DurationInMinutes = durationInMinutes;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = default;
        IsDisabled = default;
    }

    public Music ChangeProduction(Guid productionId)
    {
        ProductionId = productionId;
        return this;
    }

    public Music ChangeTitle(string title)
    {
        Title = title;
        return this;
    }

    public Music ChangeDuration(ushort durationInMinutes)
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