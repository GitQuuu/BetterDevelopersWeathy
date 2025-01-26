using Azure.Identity;

namespace Api.Extensions;

/// <summary>
/// Load key value pairs from azure key vault into appsettings
/// </summary>
public static class AzureKeyVault
{   
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void Load(WebApplicationBuilder builder)
    {
        var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();

        try
        {
            var keyVaultUrl = builder.Configuration["AzureKeyVault:VaultUri"];
            if (string.IsNullOrEmpty(keyVaultUrl))
            {
                logger.LogWarning("Azure Key Vault URI is missing. Skipping Key Vault configuration.");
                return;
            }

            var tenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID", EnvironmentVariableTarget.Machine);
            var clientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID", EnvironmentVariableTarget.Machine);
            var clientSecret = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET", EnvironmentVariableTarget.Machine);

            if (string.IsNullOrEmpty(tenantId) || string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
            {
                logger.LogWarning("EntraID credentials are missing from environment variables. Skipping Key Vault integration.");
                return;
            }

            var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);

            builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), credential);
            logger.LogInformation("Successfully loaded secrets from Azure Key Vault.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to connect to Azure Key Vault. The application will continue running without Key Vault integration.");
        }
    }
}