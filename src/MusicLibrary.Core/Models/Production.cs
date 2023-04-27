using MusicLibrary.Core.Enums;
using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models;

public class Production : TrackableEntity
{
    public virtual Guid ArtistId { get; protected internal set; }
    public virtual string Title { get; protected internal set; }
    public virtual ProductionType ProductionType { get; protected internal set; }
    public virtual ushort ReleaseYear { get; protected internal set; }

    #region Navigaton properties

    public Artist Artist { get; protected set; }
    public ICollection<Music> Musics { get; protected set; } = new List<Music>();

    #endregion

    public virtual Production ChangeTitle(string title)
    {
        Title = title;
        return this;
    }

    public virtual Production ChangeProductionType(ProductionType productionType)
    {
        ProductionType = productionType;
        return this;
    }

    public virtual Production ChangeReleaseYear(ushort releaseYear)
    {
        ReleaseYear = releaseYear;
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