using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Data.Context;

public class MusicLibraryDbContext : DbContext
{
    public MusicLibraryDbContext(DbContextOptions<MusicLibraryDbContext> options) : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = default;
    }

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Music> Musics { get; set; }
    public DbSet<Production> Productions { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}