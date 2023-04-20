using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models;

public class Artist : TrackableEntity
{
    public Guid GenreId { get; protected set; }
    public string Name { get; protected set; }

    #region Navigation properties

    public Genre Genre { get; protected set; }
    public ICollection<Production> Productions { get; protected set; } = new List<Production>();

    #endregion

    public Artist(Guid genreId, string name)
    {
        Id = Guid.NewGuid();
        GenreId = genreId;
        Name = name;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = default;
        IsDisabled = default;
    }

    public Artist ChangeGenre(Guid genreId)
    {
        GenreId = genreId;
        return this;
    }

    public Artist ChangeName(string name)
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