namespace InsuranceCalculator.Application.DTOs.Requests
{
    public record CoverageItemRequestDto
    {
        public Guid CoverageDefinationId { get; init; }
        public decimal Capital { get; init; }
    }
}
