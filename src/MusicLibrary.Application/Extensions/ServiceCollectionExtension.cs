using Microsoft.Extensions.DependencyInjection;
using MusicLibrary.Application.MapperProfiles;
using MusicLibrary.Application.Queries.Artists.ListArtists;
using MusicLibrary.Application.Services;
using MusicLibrary.Core.Contracts.Services;

namespace MusicLibrary.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureAutoMapper(this IServiceCollection servicesCollection)
    {
        return servicesCollection.AddAutoMapper(typeof(ModelToResponseProfile));
    }

    public static IServiceCollection ConfigureMediatR(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(ListArtistsHandler).Assembly);
        });
    }

    public static IServiceCollection ResolveServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<ISecurityService, SecurityService>();
    }
}