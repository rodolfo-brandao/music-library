using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace MusicLibrary.Presentation.Extensions;

internal static class MvcBuilderExtension
{
    public static IMvcBuilder ConfigureMvc(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddMvc(options =>
        {
            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            options.Filters.Add(new AuthorizeFilter(policy));
        });
    }
}