using InsuranceCalculator.Domain.Entities.UserManagement;
using InsuranceCalculator.Domain.ValueObjects;

namespace InsuranceCalculator.Domain.Factories;

internal class UserFactory : IUserFactory
{
    public User Create(BaseId id, Guid token, string firstName, string lastName)
        => new(id, token, firstName, lastName);
}
