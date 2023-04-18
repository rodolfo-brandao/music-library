namespace MusicLibrary.Core.Models.Nulls;

public class NullGenre : Genre
{
    public NullGenre(string name) : base(name)
    {
        Id = default;
        Name = default;
        Artists = default;
        CreatedAt = default;
        UpdatedAt = default;
        IsDisabled = default;
    }
}