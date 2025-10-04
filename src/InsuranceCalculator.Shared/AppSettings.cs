namespace InsuranceCalculator.Shared;

public record AppSettings
{
    public static string ConfigurationSectionName => nameof(AppSettings);

    public string LoggingBehavior { get; set; } = string.Empty;
}