using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Shared.Abstraction.Commands;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result.Result>
    where TCommand : class, ICommandRequest
{
}

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommandRequest<TResponse>
    where TResponse : class
{
}
