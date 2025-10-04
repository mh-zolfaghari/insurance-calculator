using InsuranceCalculator.Application.DTOs;
using InsuranceCalculator.Shared.Abstraction.Queries;
using InsuranceCalculator.Shared.Abstraction.Security;

namespace InsuranceCalculator.Application.UseCases.User.Queries;

public record GetUsersQuery : IQueryRequest<IEnumerable<UserDto>>, IAnonymousRequest
{
}
