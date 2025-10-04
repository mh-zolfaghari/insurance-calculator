using InsuranceCalculator.Application.DTOs.Requests;
using InsuranceCalculator.Shared.Abstraction.Commands;

namespace InsuranceCalculator.Application.UseCases.InsuranceRequest.Commands.CreateInsuranceRequest;

public record CreateInsuranceRequestCommand : ICommandRequest
{
    public string Title { get; set; } = string.Empty;
    public IEnumerable<CoverageItemRequestDto> CoverageItems { get; set; } = [];
}
