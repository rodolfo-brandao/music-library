namespace MusicLibrary.Presentation.Extensions;

internal static class ApplicationBuilderExtension
{
    public static IApplicationBuilder AddCustomCorsPolicy(this IApplicationBuilder applicationBuilder)
    {
        return applicationBuilder.UseCors(corsPolicyBuilder =>
        {
            corsPolicyBuilder.AllowAnyOrigin();
            corsPolicyBuilder.AllowAnyMethod();
            corsPolicyBuilder.AllowAnyHeader();
        });
    }
    
    public static IApplicationBuilder AddCustomSwaggerUse(this IApplicationBuilder applicationBuilder)
    {
        return applicationBuilder
            .UseSwagger()
            .UseSwaggerUI(options => { options.DefaultModelsExpandDepth(-1); });
    }
}
