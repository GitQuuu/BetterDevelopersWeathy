namespace Api.Extensions;

public static class MiddlewareExtensions
{
  
    /// <summary>
    /// SwaggerUi extensions
    /// </summary>
    /// <param name="app"></param>
    public  static void UseSwaggerUiExtensions(this IApplicationBuilder app)
    {
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "My BetterDevelopersWeathy api V1");
            options.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
        });
    }
}