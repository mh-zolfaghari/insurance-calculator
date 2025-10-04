using InsuranceCalculator.Shared.Result;
using InsuranceConfiguration.Shared.Abstraction.Validators;

namespace InsuranceCalculator.Shared.Abstraction.Commands;

public interface ICommand : IRequestValidator
{
}

public interface ICommandRequest : ICommand, IRequest<Result.Result>
{
}

public interface ICommandRequest<TResponse> : ICommand, IRequest<Result<TResponse>>
{
}
