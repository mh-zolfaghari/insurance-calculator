using InsuranceCalculator.Domain.Entities.UserManagement;
using InsuranceCalculator.Domain.Repositories.UserManagement;
using InsuranceCalculator.Infrastructure.Persistence.EF.Context;
using InsuranceCalculator.Shared.Abstraction.Commons;

namespace InsuranceCalculator.Infrastructure.Persistence.EF.Repositories;

internal class UserRepository(AppDbContext dbContext) : IUserRepository
{
    public Task<User> GetUserByTokenAsync(IClientToken clientToken, CancellationToken cancellationToken)
        => dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Token == clientToken.Token, cancellationToken)!;

    public async Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken)
        => await dbContext.Users
            .AsNoTracking()
            .ToListAsync(cancellationToken);
}
