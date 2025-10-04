using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.Exceptions;
using InsuranceCalculator.Domain.Primitives;
using InsuranceCalculator.Domain.ValueObjects;
using InsuranceCalculator.Shared.Abstraction.Commons;

namespace InsuranceCalculator.Domain.Entities.UserManagement
{
    public class User : BaseEntity, IClientToken
    {
        private readonly List<InsuranceRequest> _insuranceRequests = new();

        public Guid Token { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public IReadOnlyCollection<InsuranceRequest> InsuranceRequests => _insuranceRequests.AsReadOnly();

        private User() { }

        internal User
            (
                BaseId id,
                Guid token,
                string firstName,
                string lastName
            )
        {
            if (token == Guid.Empty)
                throw new TokenEmptyException();

            if (!string.IsNullOrWhiteSpace(firstName) && firstName.Length > 100)
                throw new FirstNameTooLongException();

            if (!string.IsNullOrWhiteSpace(lastName) && lastName.Length > 100)
                throw new LastNameTooLongException();

            Id = id;
            Token = token;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
