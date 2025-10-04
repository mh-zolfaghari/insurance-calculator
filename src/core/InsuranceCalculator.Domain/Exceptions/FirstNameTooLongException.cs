using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Domain.Exceptions;

internal class FirstNameTooLongException : UserManagementException
{
    public FirstNameTooLongException() : base("The FirstName length should not exceed 100 characters.")
    {
    }
}
