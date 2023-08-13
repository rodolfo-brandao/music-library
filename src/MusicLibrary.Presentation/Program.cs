using MusicLibrary.Application.Extensions;
using MusicLibrary.Data.Extensions;
using MusicLibrary.Presentation.Extensions;
using MusicLibrary.Presentation.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddCustomApiVersioning();
    builder.Services.AddCustomAutoMapper();
    builder.Services.AddCustomMediatR();
    builder.Services.AddCustomServices();
    builder.Services.AddCustomAuthorizationPolicy(configuration);
    builder.Services.AddCustomDbContext(configuration);
    builder.Services.AddCustomRouting();
    builder.Services.AddCustomSwagger(configuration);
    builder.Services.AddCustomFactories();
    builder.Services.AddCustomRepositories();
    builder.Services.AddCustomUnitsOfWork();
    builder.Services.AddCustomMvc();
    builder.Services.AddCustomSerilog(builder.Host);
}

var app = builder.Build();

{
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage().AddCustomSwaggerUse();
    }

    app.AddCustomCorsPolicy();
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseMiddleware<ExceptionMiddleware>();
    app.MapControllers();
    app.UseSerilogRequestLogging();
    app.MapControllers();
    app.Run();
}
