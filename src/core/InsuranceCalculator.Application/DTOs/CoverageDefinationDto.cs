namespace InsuranceCalculator.Application.DTOs;

public record CoverageDefinationDto : BaseDto<Guid>
{
    public string? Name { get; init; }
    public decimal? Minimum { get; init; }
    public decimal? Maximum { get; init; }
    public decimal? PremiumRate { get; init; }
}
