using MusicLibrary.Core.Enums;
using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models.Nulls;

public sealed class NullProduction : Production, INullObject
{
    public override Guid ArtistId => Guid.Empty;
    public override string Title => string.Empty;
    public override ProductionType ProductionType => default;
    public override string ReleaseDate => default;

    public override Production ChangeTitle(string title)
    {
        return this;
    }

    public override Production ChangeProductionType(ProductionType productionType)
    {
        return this;
    }

    public override Production ChangeReleaseDate(string releaseDate)
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