using Microsoft.Extensions.DependencyInjection;
using MusicLibrary.Application.Queries.Artists.ListArtists;
using MusicLibrary.Core.Contracts.Services;
using MusicLibrary.Data.Services;

namespace MusicLibrary.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCustomMediatR(this IServiceCollection serviceCollection)
        => serviceCollection.AddMediatR(config =>
            config.RegisterServicesFromAssembly(typeof(ListArtistsHandler).Assembly));

    public static IServiceCollection AddCustomServices(this IServiceCollection serviceCollection)
        => serviceCollection.AddScoped<ISecurityService, SecurityService>();
}