using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Contracts.UnitsOfWork;
using MusicLibrary.Data.Context;
using MusicLibrary.Data.Repositories;
using MusicLibrary.Data.UnitsOfWork;

namespace MusicLibrary.Data.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureDbContext(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        return serviceCollection.AddDbContext<MusicLibraryDbContext>(optionsAction =>
            optionsAction.UseSqlite(connectionString));
    }

    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddScoped<IArtistRepository, ArtistRepository>()
            .AddScoped<IGenreRepository, GenreRepository>()
            .AddScoped<IMusicRepository, MusicRepository>()
            .AddScoped<IProductionRepository, ProductionRepository>()
            .AddScoped<IUserRepository, UserRepository>();
    }

    public static IServiceCollection AddUnitsOfWork(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}