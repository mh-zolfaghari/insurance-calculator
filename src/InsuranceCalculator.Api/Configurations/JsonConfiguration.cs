using InsuranceCalculator.Shared.Converters;
using InsuranceCalculator.Shared.Policies;

namespace InsuranceCalculator.Api.Configurations;

public static class JsonConfiguration
{
    public static void ConfigureJsonSettings(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(option =>
        {
            option.JsonSerializerOptions.PropertyNamingPolicy = new NamingPolicy.JsonSnakeCaseNamingPolicy();
            option.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            option.JsonSerializerOptions.Converters.Add(new DateTimeConvertor());
            option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
    }
}
