using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Domain.Exceptions;

internal class InvalidCoverageDefinitionPremiumRateException : InsuranceManagementException
{
    public InvalidCoverageDefinitionPremiumRateException() : base("PremiumRate must be non-negative.")
    {
    }
}
