namespace InsuranceCalculator.Application.DTOs
{
    public record UserInsuranceRequestsDto : BaseDto<Guid>
    {
        public string? FullName { get; init; }
        public IEnumerable<InsuranceRequestDto>? InsuranceRequests { get; set; }
    }
}
