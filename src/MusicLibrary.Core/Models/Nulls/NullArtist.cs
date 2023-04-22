using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models.Nulls;

public sealed class NullArtist : Artist, INullObject
{
    public override Guid GenreId => Guid.Empty;
    public override string Name => string.Empty;

    public override Artist ChangeGenre(Guid genreId)
    {
        return this;
    }

    public override Artist ChangeName(string name)
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