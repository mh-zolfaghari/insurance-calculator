namespace InsuranceCalculator.Shared.Result;

public record Result
{
    #region Main Props
    public bool IsSuccess { get; private init; }

    [JsonIgnore]
    public bool IsFailure => !IsSuccess;

    public Error Error { get; private init; }
    #endregion

    #region Protected Ctor
    protected Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }
    #endregion

    #region Functionalities
    public static Result Failure(Error error) => new(false, error);
    public static Result<T> Failure<T>(Error error) => Result<T>.Failure(error);
    public static Result Success() => new(true, Error.None);
    public static Result<T> Success<T>(T data) => Result<T>.Success(data);
    #endregion
}

public record Result<T> : Result
{
    public T Data { get; private init; }

    #region Private Ctor
    private Result(bool isSuccess, T data, Error error) : base(isSuccess, error) => Data = data;
    #endregion

    #region Functionalities
    public static Result<T> Success(T data) => new(true, data, Error.None);
    public new static Result<T> Failure(Error error) => new(false, default!, error);
    #endregion
}
