using MusicLibrary.Core.Enums;
using MusicLibrary.Core.Models.Abstract;

namespace MusicLibrary.Core.Models;

public class Production : TrackableEntity
{
    public Guid ArtistId { get; protected set; }
    public string Title { get; protected set; }
    public ProductionType ProductionType { get; protected set; }
    public DateOnly ReleaseDate { get; protected set; }

    #region Navigaton properties

    public Artist Artist { get; protected set; }
    public ICollection<Music> Musics { get; protected set; } = new List<Music>();

    #endregion

    public Production(Guid artistId, string title, ProductionType productionType, DateOnly releaseDate)
    {
        Id = Guid.NewGuid();
        Title = title;
        ProductionType = productionType;
        ReleaseDate = releaseDate;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = default;
        IsDisabled = default;
    }

    public Production ChangeTitle(string title)
    {
        Title = title;
        return this;
    }

    public Production ChangeProductionType(ProductionType productionType)
    {
        ProductionType = productionType;
        return this;
    }

    public Production ChangeReleaseDate(DateOnly releaseDate)
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
        UpdatedAt = DateTime.UtcNow;
        return this;
    }
}