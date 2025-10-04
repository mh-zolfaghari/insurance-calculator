using InsuranceCalculator.Application.DTOs.Requests;

namespace InsuranceCalculator.Application.UseCases.InsuranceRequest.Commands.CreateInsuranceRequest.Validators;

public class CoverageItemRequestDtoValidator : AbstractValidator<CoverageItemRequestDto>
{
    public CoverageItemRequestDtoValidator()
    {
        RuleFor(x => x.CoverageDefinationId)
            .NotEmpty().WithMessage(InsuranceRequestMessages.RequiredCoverageDefinationId.Message)
            .Must(id => id != Guid.Empty).WithMessage(InsuranceRequestMessages.InvalidCoverageDefinationIdFormat.Message);

        RuleFor(x => x.Capital)
            .NotNull().WithMessage(InsuranceRequestMessages.RequiredCoverageItemCapital.Message)
            .GreaterThanOrEqualTo(1).WithMessage(InsuranceRequestMessages.InvalidCoverageItemCapitalIdFormat.Message);
    }
}
