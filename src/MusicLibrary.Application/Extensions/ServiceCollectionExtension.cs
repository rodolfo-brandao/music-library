using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using MusicLibrary.Application.Queries.Artists.ListArtists;
using MusicLibrary.Application.Services;
using MusicLibrary.Core.Contracts.Services;

namespace MusicLibrary.Application.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCustomMediatR(this IServiceCollection serviceCollection)
        => serviceCollection.AddMediatR(config =>
            config.RegisterServicesFromAssembly(typeof(ListArtistsHandler).Assembly));

    public static IServiceCollection AddCustomServices(this IServiceCollection serviceCollection)
        => serviceCollection.AddScoped<ISecurityService, SecurityService>();
}