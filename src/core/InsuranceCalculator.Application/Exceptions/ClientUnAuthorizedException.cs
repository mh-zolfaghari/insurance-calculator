using InsuranceCalculator.Shared.Abstraction.Exceptions;

namespace InsuranceCalculator.Application.Exceptions
{
    public class ClientUnAuthorizedException : PrimitiveException
    {
        public ClientUnAuthorizedException() : base("Token is not Valid! :(")
        {
        }
    }
}
