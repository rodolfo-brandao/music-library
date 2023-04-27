using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models;

public class Artist : TrackableEntity
{
    public virtual Guid GenreId { get; protected internal set; }
    public virtual string Name { get; protected internal set; }

    #region Navigation properties

    public Genre Genre { get; protected set; }
    public ICollection<Production> Productions { get; protected set; } = new List<Production>();

    #endregion

    public virtual Artist ChangeGenre(Guid genreId)
    {
        GenreId = genreId;
        return this;
    }

    public virtual Artist ChangeName(string name)
    {
        Name = name;
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