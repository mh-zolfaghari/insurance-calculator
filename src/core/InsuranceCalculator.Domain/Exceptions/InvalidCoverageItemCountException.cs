using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Domain.Exceptions;

internal class InvalidCoverageItemCountException : InsuranceManagementException
{
    public InvalidCoverageItemCountException() : base("A request can't contain more than 3 coverage items")
    {
    }
}
