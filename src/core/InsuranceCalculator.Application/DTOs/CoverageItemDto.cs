namespace InsuranceCalculator.Application.DTOs;

public record CoverageItemDto : BaseDto<Guid>
{
    public decimal? Capital { get; init; }
    public decimal? Premium { get; init; }

    public CoverageDefinationDto? CoverageDefination { get; init; } = default;
}
