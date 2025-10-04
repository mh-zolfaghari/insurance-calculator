using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Domain.Exceptions;

internal class InvalidPremiumException : InsuranceManagementException
{
    public InvalidPremiumException() : base("Premium must be non-negative.")
    {
    }
}
