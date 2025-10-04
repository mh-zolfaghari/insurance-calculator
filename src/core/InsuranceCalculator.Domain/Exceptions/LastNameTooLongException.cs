using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Domain.Exceptions;

internal class LastNameTooLongException : UserManagementException
{
    public LastNameTooLongException() : base("The LastName length should not exceed 100 characters.")
    {
    }
}
