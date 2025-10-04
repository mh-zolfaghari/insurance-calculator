using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Domain.Exceptions;

internal class RequestTitleNullOrEmptyException : InsuranceManagementException
{
    public RequestTitleNullOrEmptyException() : base("RequestTitle can't be Null or Empty value.")
    {
    }
}
