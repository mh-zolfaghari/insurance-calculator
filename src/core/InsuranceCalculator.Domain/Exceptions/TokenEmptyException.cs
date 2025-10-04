using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Domain.Exceptions;

internal class TokenEmptyException : UserManagementException
{
    public TokenEmptyException() : base("Token can not be empty.")
    {
    }
}
