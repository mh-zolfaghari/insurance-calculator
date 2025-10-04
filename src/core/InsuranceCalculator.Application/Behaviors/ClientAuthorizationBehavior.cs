using InsuranceCalculator.Application.Exceptions;
using InsuranceCalculator.Domain.Repositories.UserManagement;
using InsuranceCalculator.Shared.Abstraction.Commons;
using InsuranceCalculator.Shared.Abstraction.Security;

namespace InsuranceCalculator.Application.Behaviors;

internal class ClientAuthorizationBehavior<TRequest, TResponse>(IUserRepository userRepository, ICurrentUserContext currentUser)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ICurrentUserContext _currentUser = currentUser;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is IAnonymousRequest)
            return await next(cancellationToken);

        if (_currentUser.Token == Guid.Empty)
            throw new ClientUnAuthorizedException();

        var foundedUser = await _userRepository.GetUserByTokenAsync(_currentUser, cancellationToken) ?? throw new ClientUnAuthorizedException();
        _currentUser.Initialize(foundedUser.Id, foundedUser.FirstName, foundedUser.LastName);

        return await next(cancellationToken);
    }
}
