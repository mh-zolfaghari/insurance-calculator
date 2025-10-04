using InsuranceCalculator.Application.DTOs;
using InsuranceCalculator.Application.Helpers;
using InsuranceCalculator.Domain.Repositories.UserManagement;
using InsuranceCalculator.Shared.Abstraction.Queries;
using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Application.UseCases.User.Queries;

public class GetUsersQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUsersQuery, IEnumerable<UserDto>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result<IEnumerable<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var result = await _userRepository.GetAllAsync(cancellationToken);
        return Result.Success<IEnumerable<UserDto>>(result.Select(x => x.ToDto()));
    }
}
