using InsuranceCalculator.Api.Configurations;
using InsuranceCalculator.Api.Extensions;
using InsuranceCalculator.Application;
using InsuranceCalculator.Domain;
using InsuranceCalculator.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
#region Application Services Configuration
// Configure HTTP settings
builder.Services.ConfigureHttpSettings();

// Binding AppSettings to the DI container
builder.Services.ConfigureAppSettings(builder.Configuration);

// Register Infrastructure Services
builder.Services
    .RegisterApplicationServices(builder.Configuration)
    .RegisterDomainServices()
    .RegisterInfrastructureServices(builder.Configuration);

// Configure JSON settings
builder.Services.ConfigureJsonSettings();

// Configures ApiExplorer using
builder.Services.AddEndpointsApiExplorer();

// Configure Application Services
// TODO: Add application services here

// Configure Exception Handling Middleware
builder.Services.ConfigureExceptionHandling();

// Register the Logging services
builder.Host.ConfigureLogging();

// Register the Swagger services
builder.Services.ConfigureSwagger();
#endregion

var app = builder.Build();
#region Application Configuration
app.UseExceptionHandler();

app.RegisterMiddlewaresInDevelopmentMode(async () =>
{
    // Initialize and seed the database
    await app.InitializeDatabaseAsync();
});

app.RegisterMiddlewaresInProductionMode(() =>
{
    app.UseHsts();
});

// Configure the Swagger middleware
app.ConfigureSwaggerUI();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.ConfigureSeilog();
#endregion
app.Run();
