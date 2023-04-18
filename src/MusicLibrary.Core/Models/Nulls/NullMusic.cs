namespace MusicLibrary.Core.Models.Nulls;

public class NullMusic : Music
{
    public NullMusic(Guid productionId, string title, ushort durationInMinutes) : base(productionId, title,
        durationInMinutes)
    {
        Id = default;
        ProductionId = default;
        Title = default;
        DurationInMinutes = default;
        Production = default;
        CreatedAt = default;
        UpdatedAt = default;
        IsDisabled = default;
    }
}