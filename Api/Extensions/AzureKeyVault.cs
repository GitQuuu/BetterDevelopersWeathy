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
        // Load Azure Key Vault secrets into appsettings
        var keyVaultUrl = builder.Configuration["AzureKeyVault:VaultUri"];
        if (!string.IsNullOrEmpty(keyVaultUrl))
        {
            var credential = new ClientSecretCredential(
                Environment.GetEnvironmentVariable("AZURE_TENANT_ID",EnvironmentVariableTarget.Machine), 
                Environment.GetEnvironmentVariable("AZURE_CLIENT_ID",EnvironmentVariableTarget.Machine), 
                Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET",EnvironmentVariableTarget.Machine));

            builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), credential);
        }
    }
}