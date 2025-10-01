using InsuranceCalculator.Api.Configurations;
using InsuranceCalculator.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
#region Application Services Configuration
// Configure HTTP settings
builder.Services.ConfigureHttpSettings();

// Binding AppSettings to the DI container
builder.Services.ConfigureAppSettings(builder.Configuration);

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
app.RegisterMiddlewaresInDevelopmentMode(() =>
{
    // TODO: Enable seed data for local testing


    // Configure the Swagger middleware
    app.ConfigureSwaggerUI();
});
app.RegisterMiddlewaresInProductionMode(() =>
{
    app.UseHsts();
});
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.ConfigureSeilog();
#endregion
app.Run();
