namespace InsuranceCalculator.Api.Configurations;

public static class SwaggerConfiguration
{
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Insurance Calculator",
                Version = "v1",
                Description = "API for calculating insurance premiums based on various factors.",
                Contact = new OpenApiContact
                {
                    Name = "Mohammad Hossein Zolfaghari",
                    Email = "personal.mhz@gmail.com",
                    Url = new Uri("https://www.linkedin.com/in/ronixa/")
                }
            });
        });
    }

    public static void ConfigureSwaggerUI(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint($"/swagger/v1/swagger.json", $"Insurance Calculator API v1");
            options.DefaultModelsExpandDepth(-1);
        });
    }
}
