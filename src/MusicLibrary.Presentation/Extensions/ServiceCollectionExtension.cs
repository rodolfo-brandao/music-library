using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MusicLibrary.Application.Utils;
using Serilog;

namespace MusicLibrary.Presentation.Extensions;

internal static class ServiceCollectionExtension
{
    private const string ApiVersioningFormat = "'v'VVV";
    private const string BearerTokenFormat = "JWT";
    private const string CurrentApiVersion = "v1";
    private const ushort MajorApiVersion = 1;
    private const ushort MinorApiVersion = default;

    #region Public methods

    public static IServiceCollection AddCustomApiVersioning(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(MajorApiVersion, MinorApiVersion);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
        }).AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = ApiVersioningFormat;
            options.SubstituteApiVersionInUrl = true;
        });
    }

    public static IServiceCollection AddCustomAuthorizationPolicy(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var jwtSecret = configuration.GetSection("Jwt:Secret").Value;
        var jwtSecretBytes = Encoding.ASCII.GetBytes(jwtSecret ?? string.Empty);
        const string adminAuthorizationRole = AuthorizationRoles.Admin;
        const string userAuthorizationRole = AuthorizationRoles.User;

        _ = serviceCollection.AddAuthorization(options =>
        {
            options.AddPolicy(adminAuthorizationRole, policy => policy.RequireClaim("User", adminAuthorizationRole));
            options.AddPolicy(userAuthorizationRole, policy => policy.RequireClaim("User", userAuthorizationRole));
        }).AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = default;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(jwtSecretBytes),
                ValidateIssuer = default,
                ValidateAudience = default
            };
        });

        return serviceCollection;
    }

    public static IServiceCollection AddCustomRouting(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddRouting(routeOptions =>
        {
            routeOptions.LowercaseUrls = true;
        });
    }

    public static IServiceCollection AddCustomSerilog(this IServiceCollection serviceCollection, ConfigureHostBuilder configureHostBuilder)
    {
        var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configurationBuilder).CreateLogger();
        Log.Debug("Starting application...");
        configureHostBuilder.UseSerilog();
        return serviceCollection.AddSingleton(Log.Logger);
    }

    public static IServiceCollection AddCustomSwagger(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        return serviceCollection.AddSwaggerGen(options =>
        {
            var openApiInfo = GetOpenApiInfo(configuration);

            options.SwaggerDoc("v1", openApiInfo);
            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Description = $"{BearerTokenFormat} authorization header using {JwtBearerDefaults.AuthenticationScheme} scheme. \r\n\r\nTo authenticate, simply enter '{JwtBearerDefaults.AuthenticationScheme} <your_access_token>'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = BearerTokenFormat,
                Type = SecuritySchemeType.ApiKey
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = JwtBearerDefaults.AuthenticationScheme,
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    Array.Empty<string>()
                }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });
    }

    #endregion

    #region Private methods

    private static OpenApiInfo GetOpenApiInfo(IConfiguration configuration) => new()
    {
        Version = CurrentApiVersion,
        Title = configuration.GetSection("OpenApiInfo:Title").Value,
        Description = configuration.GetSection("OpenApiInfo:Description").Value,
        Contact = new OpenApiContact
        {
            Name = configuration.GetSection("OpenApiInfo:Contact:Name").Value,
            Url = new Uri(configuration.GetSection("OpenApiInfo:Contact:Url").Value ?? string.Empty)
        },
        License = new OpenApiLicense
        {
            Name = configuration.GetSection("OpenApiInfo:License:Name").Value,
            Url = new Uri(configuration.GetSection("OpenApiInfo:License:Url").Value ?? string.Empty)
        }
    };

    #endregion
}
