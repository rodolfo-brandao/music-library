using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Contracts.Units;
using MusicLibrary.Core.Factories;
using MusicLibrary.Data.DbContexts;
using MusicLibrary.Data.Repositories;
using MusicLibrary.Data.Units;
using StackExchange.Redis;

namespace MusicLibrary.Data.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtension
{
    /// <summary>
    /// SQLite Database.
    /// </summary>
    public static IServiceCollection AddCustomDbContext(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        return serviceCollection.AddDbContext<MusicLibraryDbContext>(options =>
            options.UseSqlite(connectionString));
    }

    public static IServiceCollection AddCustomFactories(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IModelFactory, ModelFactory>();
    }

    public static IServiceCollection AddCustomRedisInstance(this IServiceCollection servicesCollection,
        IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("RedisConnectionString") ?? "localhost";
        return servicesCollection.AddSingleton<IConnectionMultiplexer>(_ =>
            ConnectionMultiplexer.Connect(connectionString));
    }

    public static IServiceCollection AddCustomRepositories(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddScoped<IArtistRepository, ArtistRepository>()
            .AddScoped<IGenreRepository, GenreRepository>()
            .AddScoped<IProductionRepository, ProductionRepository>()
            .AddScoped<ITrackRepository, TrackRepository>();
    }

    public static IServiceCollection AddCustomUnitsOfWork(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}