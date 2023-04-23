using MusicLibrary.Data.Extensions;
using MusicLibrary.Presentation.Extensions;
using MusicLibrary.Presentation.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.ConfigureApiVersioning();
builder.Services.AddAuthorizationPolicy(configuration);
builder.Services.ConfigureDbContext(configuration);
builder.Services.ConfigureRouting();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger(configuration);
builder.Services.AddRepositories();
builder.Services.AddUnitsOfWork();
builder.Services.ConfigureMvc();
builder.Services.ConfigureSerilog(builder.Host);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage().ConfigureSwaggerUse();
}

app.ConfigureCors();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
app.UseSerilogRequestLogging();
app.MapControllers();
app.Run();