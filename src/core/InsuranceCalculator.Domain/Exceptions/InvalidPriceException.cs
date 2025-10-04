using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Domain.Exceptions;

internal class InvalidPriceException : InsuranceManagementException
{
    public InvalidPriceException() : base("Price cannot be negative")
    {
    }
}