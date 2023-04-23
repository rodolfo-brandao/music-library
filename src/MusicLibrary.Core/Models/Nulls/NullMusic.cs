using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models.Nulls;

public sealed class NullMusic : Music, INullObject
{
    public override Guid ProductionId => Guid.Empty;
    public override byte OrdinalPosition => default;
    public override string Title => string.Empty;
    public override float DurationInMinutes => default;

    public override Music ChangeProduction(Guid productionId)
    {
        return this;
    }

    public override Music ChangeOrdinalPosition(byte ordinalPosition)
    {
        return this;
    }

    public override Music ChangeTitle(string title)
    {
        return this;
    }

    public override Music ChangeDuration(float durationInMinutes)
    {
        return this;
    }

    public override TrackableEntity Disable()
    {
        return this;
    }

    public override TrackableEntity Enable()
    {
        return this;
    }

    public override TrackableEntity UpdateNow()
    {
        return this;
    }
}