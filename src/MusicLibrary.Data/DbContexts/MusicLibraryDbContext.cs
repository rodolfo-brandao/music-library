using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Core.Models;
using MusicLibrary.Data.Extensions;

namespace MusicLibrary.Data.DbContexts;

[ExcludeFromCodeCoverage]
public sealed class MusicLibraryDbContext : DbContext
{
    /// <summary>
    /// Public constructor for the sole purpose of mocking tests.
    /// </summary>
    public MusicLibraryDbContext()
    {
    }

    public MusicLibraryDbContext(DbContextOptions<MusicLibraryDbContext> options) : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = default;
    }

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Production> Productions { get; set; }
    public DbSet<Track> Tracks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly())
            .SeedModel<Genre>("../MusicLibrary.Core/Models/Seeds/genreSeed.json")
            .SeedModel<Artist>("../MusicLibrary.Core/Models/Seeds/artistSeed.json")
            .SeedModel<Production>("../MusicLibrary.Core/Models/Seeds/productionSeed.json")
            .SeedModel<Track>("../MusicLibrary.Core/Models/Seeds/trackSeed.json");

        base.OnModelCreating(modelBuilder);
    }
}