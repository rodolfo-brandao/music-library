namespace MusicLibrary.Core.Models.Nulls;

public class NullArtist : Artist
{
    public NullArtist(Guid genreId, string name) : base(genreId, name)
    {
        Id = default;
        GenreId = default;
        Name = default;
        Genre = default;
        Productions = default;
        CreatedAt = default;
        UpdatedAt = default;
        IsDisabled = default;
    }
}