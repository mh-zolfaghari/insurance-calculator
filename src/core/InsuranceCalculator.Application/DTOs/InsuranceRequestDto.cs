namespace InsuranceCalculator.Application.DTOs
{
    public record InsuranceRequestDto : BaseDto<Guid>
    {
        public DateTime? CreatedAt { get; init; }
        public decimal? TotalCapital { get; init; }
        public decimal? TotalPremium { get; init; }

        public UserDto? User { get; init; }
        public IEnumerable<CoverageItemDto>? CoverageItems { get; init; }
    }
}
