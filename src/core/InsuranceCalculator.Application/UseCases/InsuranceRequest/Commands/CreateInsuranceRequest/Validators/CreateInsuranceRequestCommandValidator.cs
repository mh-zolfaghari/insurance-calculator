namespace InsuranceCalculator.Application.UseCases.InsuranceRequest.Commands.CreateInsuranceRequest.Validators;

public class CreateInsuranceRequestCommandValidator : AbstractValidator<CreateInsuranceRequestCommand>
{
    public CreateInsuranceRequestCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(InsuranceRequestMessages.InvalidCoverageItemCapitalIdFormat.Message)
            .MaximumLength(150).WithMessage(InsuranceRequestMessages.TooManyInsuranceRequestTitle.Message);

        RuleFor(x => x.CoverageItems)
            .NotNull().WithMessage(InsuranceRequestMessages.RequiredCoverageItem.Message)
            .Must(items => items.Any()).WithMessage(InsuranceRequestMessages.LeastOneCoverageItem.Message);

        RuleForEach(x => x.CoverageItems)
            .SetValidator(new CoverageItemRequestDtoValidator());
    }
}
