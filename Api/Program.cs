using Api.Extensions;
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
builder.Services.AddServicesExtension();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
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
app.UseSwagger();
app.UseSwaggerUiExtensions();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();