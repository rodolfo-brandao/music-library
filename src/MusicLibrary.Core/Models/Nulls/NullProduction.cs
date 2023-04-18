using MusicLibrary.Core.Enums;

namespace MusicLibrary.Core.Models.Nulls;

public class NullProduction : Production
{
    public NullProduction(Guid artistId, string title, ProductionType productionType, DateOnly releaseDate) : base(
        artistId, title, productionType, releaseDate)
    {
        Id = default;
        ArtistId = default;
        Title = default;
        ProductionType = default;
        ReleaseDate = default;
        Artist = default;
        Musics = default;
        CreatedAt = default;
        UpdatedAt = default;
        IsDisabled = default;
    }
}