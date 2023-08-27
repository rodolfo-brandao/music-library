namespace MusicLibrary.Application.Responses.Genres;

public class CreatedGenreResponse
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public DateTime CreatedOn { get; init; }
}