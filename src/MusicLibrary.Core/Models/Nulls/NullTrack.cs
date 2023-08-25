using System.Diagnostics.CodeAnalysis;
using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models.Nulls;

[ExcludeFromCodeCoverage]
public sealed class NullTrack : Track, INullObject
{
    public override Guid ProductionId => Guid.Empty;
    public override byte Position => default;
    public override string Title => string.Empty;
    public override float Length => default;

    public override Track ChangeProduction(Guid productionId)
    {
        return this;
    }

    public override Track ChangePosition(byte position)
    {
        return this;
    }

    public override Track ChangeTitle(string title)
    {
        return this;
    }

    public override Track ChangeLength(float length)
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