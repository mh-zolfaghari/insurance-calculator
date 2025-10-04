using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Domain.Exceptions;

internal class InvalidCapitalException : InsuranceManagementException
{
    public InvalidCapitalException() : base("Capital must be non-negative.")
    {
    }
}
