using Microsoft.Extensions.DependencyInjection;
using MusicLibrary.Application.Queries.Artists.ListArtists;
using MusicLibrary.Application.Services;
using MusicLibrary.Core.Contracts.Services;

namespace MusicLibrary.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCustomMediatR(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(ListArtistsHandler).Assembly);
        });
    }

    public static IServiceCollection AddCustomServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<ISecurityService, SecurityService>();
    }
}
