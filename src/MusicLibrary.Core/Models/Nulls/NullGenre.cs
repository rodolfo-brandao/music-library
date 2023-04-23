using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models.Nulls;

public sealed class NullGenre : Genre, INullObject
{
    public override string Name => string.Empty;

    public override Genre ChangeName(string name)
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