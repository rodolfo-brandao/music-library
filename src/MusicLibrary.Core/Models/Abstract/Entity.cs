namespace MusicLibrary.Core.Models.Abstract;

public abstract class Entity
{
    public Guid Id { get; protected internal set; }
}