namespace MusicLibrary.Presentation.Extensions;

internal static class ApplicationBuilderExtension
{
    public static IApplicationBuilder AddCustomCorsPolicy(this IApplicationBuilder applicationBuilder)
        => applicationBuilder.UseCors(corsPolicyBuilder =>
        {
            corsPolicyBuilder.AllowAnyOrigin();
            corsPolicyBuilder.AllowAnyMethod();
            corsPolicyBuilder.AllowAnyHeader();
        });

    public static IApplicationBuilder AddCustomSwaggerUse(this IApplicationBuilder applicationBuilder)
        => applicationBuilder.UseSwagger().UseSwaggerUI(options => options.DefaultModelsExpandDepth(-1));
}