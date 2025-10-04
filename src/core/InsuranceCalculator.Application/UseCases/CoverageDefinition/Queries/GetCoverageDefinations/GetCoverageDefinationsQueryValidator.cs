namespace InsuranceCalculator.Application.UseCases.CoverageDefinition.Queries.GetCoverageDefinations
{
    public class GetCoverageDefinationsQueryValidator : AbstractValidator<GetCoverageDefinationsQuery>
    {
        public GetCoverageDefinationsQueryValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(300).WithMessage(CoverageDefinitionMessages.InvalidName.Message);
        }
    }
}
