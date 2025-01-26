namespace Api.Extensions;

/// <summary>
/// To keep the program.cs free of clutter
/// </summary>
public static class MiddlewareExtensions
{
  
    /// <summary>
    /// SwaggerUi extensions
    /// </summary>
    /// <param name="app"></param>
    public static void UseSwaggerUiExtensions(this IApplicationBuilder app)
    {
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "My BetterDevelopersWeathy api v1");
            options.SwaggerEndpoint("/swagger/v2/swagger.json", "My BetterDevelopersWeathy api v2");
            options.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
            
        });
    }
}