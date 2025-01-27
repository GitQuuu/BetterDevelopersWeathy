using System.Reflection;
using Asp.Versioning;
using DAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Refit;
using Services.AccountService;
using Services.External.WeatherApiWebService;
using Services.ResponseService;
using Services.UserManagerService;
using Services.WeatherService;

namespace Api.Extensions;

/// <summary>
/// To keep the program.cs clean from clutters
/// </summary>
public static class ServiceRegistrationExtensions
{
    /// <summary>
    /// Cors extensions
    /// </summary>
    /// <param name="services"></param>
    public static void AddCorsExtension(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowBetterWeathy",
                policy =>
                {
                    policy.WithOrigins("https://betterweathy.netlify.app")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
        });
    }
    /// <summary>
    /// SwaggerGen extensions
    /// </summary>
    /// <param name="services"></param>
    public static void AddSwaggerGenExtension(this IServiceCollection services)
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        services.AddSwaggerGen(
            c =>
            {
               
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BetterDevelopersWeathy API",
                    Version = "v1",
                    Description =
                        $"API documentation for the BetterDevelopers weather application last updated {DateTime.UtcNow}",
                    Contact = new OpenApiContact
                    {
                        Name = "Qu",
                        Email = "DevQu@hotmail.com",
                    }
                });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "BetterDevelopersWeathy API", Version = "v2" });
                
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), true);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Enter JWT Token",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        []
                    }
                });
            }
        );
    }

    /// <summary>
    /// Enable versioning with swagger
    /// </summary>
    /// <param name="services"></param>
    public static void AddApiVersioningExtension(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        
    }
    
    /// <summary>
    /// Centralizing DBContext configurations
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public static void AddDbContextExtension(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to the container.
        var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString));

    }

    /// <summary>
    ///  Identity configuration extension
    /// </summary>
    /// <param name="services"></param>
    public static void AddDefaultIdentityExtension(this IServiceCollection services)
    {
        services.AddDefaultIdentity<IdentityUser>(
                options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequiredLength = 7;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
    }

    /// <summary>
    /// Service registration extension
    /// </summary>
    /// <param name="services"></param>
    public static void AddServicesExtension(this IServiceCollection services)
    {
        services.AddScoped<IWeatherBll, WeatherBll>();
        services.AddScoped<IWeatherService, WeatherService>();
        services.AddScoped<IResponseService, ResponseService>();
        services.AddScoped<IAccountBll, AccountBll>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IUserManagerService, UserManagerService>();
    }
    
     /// <summary>
    /// Centralizing httpClient configurations
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public static void AddHttpClientExtension(this IServiceCollection services, IConfiguration configuration )
    {
        // Bind Refit settings
        services.Configure<WeatherApiConfigurations>(
            configuration.GetSection("WeatherApi"));

        // Register Refit client
        services.AddRefitClient<IWeatherApiWebService>()
            .ConfigureHttpClient((provider, client) =>
            {
                var settings = provider.GetRequiredService<IOptions<WeatherApiConfigurations>>().Value;
               
                // Validate token
                if (string.IsNullOrEmpty(settings.Key))
                {
                    throw new InvalidOperationException("API key not found");
                }

                // Validate endpoint
                if (string.IsNullOrEmpty(settings.Endpoint))
                {
                    throw new InvalidOperationException("Base address not found");
                }

                // Set the BaseAddress and headers
                client.BaseAddress = new Uri(settings.Endpoint);
                client.DefaultRequestHeaders.Add("Key", $"{settings.Key}");
            });
    }

}