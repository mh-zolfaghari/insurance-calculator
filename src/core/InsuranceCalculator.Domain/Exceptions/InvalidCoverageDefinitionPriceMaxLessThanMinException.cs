using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Domain.Exceptions;

internal class InvalidCoverageDefinitionPriceMaxLessThanMinException : InsuranceManagementException
{
    public InvalidCoverageDefinitionPriceMaxLessThanMinException() : base("MaximumPrice can not less than of MinimumPrice.")
    {
    }
}
