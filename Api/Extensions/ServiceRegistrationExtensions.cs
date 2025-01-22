using System.Reflection;
using Microsoft.OpenApi.Models;

namespace Api.Extensions;

/// <summary>
/// To keep the program.cs clean from clutters
/// </summary>
public static class ServiceRegistrationExtensions
{
    /// <summary>
    /// SwaggerGen middleware
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
                    Description = $"API documentation for the BetterDevelopers weather application last updated {DateTime.UtcNow}",
                    Contact = new OpenApiContact
                    {
                        Name = "Qu",
                        Email = "DevQu@hotmail.com",
                    }
                });
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename),true);
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
}