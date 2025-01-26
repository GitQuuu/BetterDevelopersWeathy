using Api.Extensions;
using Azure.Identity;
using Mapster;

TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContextExtension(builder.Configuration);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllers();
builder.Services.AddHttpClientExtension(builder.Configuration);
builder.Services.AddDefaultIdentityExtension();
builder.Services.AddSwaggerGenExtension();
builder.Services.AddApiVersioningExtension();
builder.Services.AddServicesExtension();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(options =>
    {
        options.AllowAnyHeader();
        options.AllowAnyMethod();
        options.AllowAnyOrigin();
    });
    app.UseSwagger();
    app.UseSwaggerUiExtensions();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();