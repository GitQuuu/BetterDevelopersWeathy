using System.Reflection;
using System.Text;
using Asp.Versioning;
using DAL.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Refit;
using Services.AccountService;
using Services.External.WeatherApiWebService;
using Services.ResponseService;
using Services.SignInManagerService;
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
    ///  Extension method of AddAuthentication.
    /// </summary>
    /// <param name="services"></param>
    /// <exception cref="InvalidOperationException">Throw if jwt key is null</exception>
    public static void AddAuthenticationExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme             = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken            = true;
                options.RequireHttpsMetadata = true;
						
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer           = true,
                    ValidIssuer              = configuration["Jwt:issuer"] ?? throw new InvalidOperationException("Missing Jwt:issuer"),
                    ValidateAudience         = true,
                    ValidAudience            = configuration["Jwt:audience"] ?? throw new InvalidOperationException("Missing Jwt:audience"),
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? throw new InvalidOperationException("Missing Jwt:Key"))),
                    ValidateLifetime         = true,
                    ClockSkew                = TimeSpan.Zero,
			
                };
					
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        // Write to console until implementing logging
                        Console.WriteLine("Authentication failed.", context.Exception);
                        return Task.CompletedTask;
                    },
                    // Handle other events as needed
                };
            });
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
        services.AddScoped<ISignInManagerService, SignInManagerService>();
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