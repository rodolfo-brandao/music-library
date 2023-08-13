using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Contracts.Unities;
using MusicLibrary.Core.Factories;
using MusicLibrary.Data.Context;
using MusicLibrary.Data.Repositories;
using MusicLibrary.Data.Unities;

namespace MusicLibrary.Data.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCustomDbContext(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        return serviceCollection.AddDbContext<MusicLibraryDbContext>(optionsAction => optionsAction.UseSqlite(connectionString));
    }

    public static IServiceCollection AddCustomFactories(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IModelFactory, ModelFactory>();
    }

    public static IServiceCollection AddCustomRepositories(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddScoped<IArtistRepository, ArtistRepository>()
            .AddScoped<IGenreRepository, GenreRepository>()
            .AddScoped<IMusicRepository, MusicRepository>()
            .AddScoped<IProductionRepository, ProductionRepository>()
            .AddScoped<IUserRepository, UserRepository>();
    }

    public static IServiceCollection AddCustomUnitiesOfWork(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
