using InsuranceCalculator.Domain.Entities.InsuranceManagement;
using InsuranceCalculator.Domain.Repositories.InsuranceManagement;
using InsuranceCalculator.Domain.RequestModels;
using InsuranceCalculator.Infrastructure.Extensions;
using InsuranceCalculator.Infrastructure.Persistence.EF.Context;
using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Infrastructure.Persistence.EF.Repositories;

internal class InsuranceRequestRepository(AppDbContext dbContext) : IInsuranceRequestRepository
{
    public async Task<Result> AddAsync(InsuranceRequest insuranceRequest, CancellationToken cancellationToken)
    {
        await dbContext.InsuranceRequests.AddAsync(insuranceRequest, cancellationToken);
        return await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<InsuranceRequest>?> GetAllWithUserIdAsync(UserInsuranceRequestModel request, CancellationToken cancellationToken)
        => await dbContext.InsuranceRequests
                .AsNoTracking()
                .Include(x => x.Items).ThenInclude(i => i.CoverageDefinition)
                .Where(ir => ir.UserId == request.UserId)
                .OrderByDescending(ir => ir.CreatedAt)
                .ApplyPaging(request)
                .ToListAsync(cancellationToken);
}
