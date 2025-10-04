using InsuranceConfiguration.Shared.Abstraction.Validators;

namespace InsuranceCalculator.Shared.Abstraction.Queries;

public interface IQuery : IRequestValidator
{
}

public interface IQueryRequest : IQuery, IRequest<Result.Result>
{
}

public interface IQueryRequest<TResponse> : IQuery, IRequest<Result.Result<TResponse>>
{
}
