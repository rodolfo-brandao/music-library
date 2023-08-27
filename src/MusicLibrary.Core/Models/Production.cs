using MusicLibrary.Core.Enums;
using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models;

public class Production : TrackableEntity
{
    public virtual Guid ArtistId { get; protected internal set; }
    public virtual string Title { get; protected internal set; }
    public virtual Category Category { get; protected internal set; }
    public virtual string ReleaseDate { get; protected internal set; }

    #region Navigaton properties

    public Artist Artist { get; protected set; }
    public ICollection<Track> Tracks { get; protected set; } = new List<Track>();

    #endregion

    public virtual Production ChangeTitle(string title)
    {
        Title = title;
        return this;
    }

    public virtual Production ChangeCategory(Category category)
    {
        Category = category;
        return this;
    }

    public virtual Production ChangeReleaseDate(string releaseDate)
    {
        ReleaseDate = releaseDate;
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
        UpdatedOn = DateTime.UtcNow;
        return this;
    }
}