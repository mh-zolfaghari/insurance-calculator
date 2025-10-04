using InsuranceCalculator.Domain.Entities.UserManagement;
using InsuranceCalculator.Domain.ValueObjects;
using InsuranceCalculator.Shared.Abstraction.Commons;

namespace InsuranceCalculator.Domain.Repositories.UserManagement;

public interface IUserRepository
{
    Task<User> GetUserByTokenAsync(IClientToken clientToken, CancellationToken cancellationToken);
    Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken);
}
