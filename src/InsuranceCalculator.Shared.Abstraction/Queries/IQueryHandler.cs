using InsuranceCalculator.Shared.Result;

namespace InsuranceCalculator.Shared.Abstraction.Queries;

public interface IQueryHandler<in TQuery> : IRequestHandler<TQuery, Result.Result>
    where TQuery : class, IQueryRequest
{
}

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQueryRequest<TResponse>
    where TResponse : class
{
}
