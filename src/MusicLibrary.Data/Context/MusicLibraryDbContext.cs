using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Core.Models;
using MusicLibrary.Data.Extensions;

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
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly())
            .SeedModel<User>("../MusicLibrary.Core/Models/Seeds/userSeed.json")
            .SeedModel<Genre>("../MusicLibrary.Core/Models/Seeds/genreSeed.json")
            .SeedModel<Artist>("../MusicLibrary.Core/Models/Seeds/artistSeed.json")
            .SeedModel<Production>("../MusicLibrary.Core/Models/Seeds/productionSeed.json")
            .SeedModel<Music>("../MusicLibrary.Core/Models/Seeds/musicSeed.json");

        base.OnModelCreating(modelBuilder);
    }
}