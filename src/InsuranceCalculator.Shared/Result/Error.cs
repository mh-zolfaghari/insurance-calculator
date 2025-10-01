namespace InsuranceCalculator.Shared.Result;

public record Error
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.None);

    public static implicit operator Result(Error error) => Result.Failure(error);

    #region Private Ctor
    private Error(string code, string message, ErrorType type, object? metaData = null)
    {
        Code = code;
        Message = message;
        Type = type;
        MetaData = metaData;
    }
    #endregion

    #region Props
    public string Code { get; private init; }
    public string Message { get; private init; }
    public ErrorType Type { get; private init; }
    public object? MetaData { get; private init; }
    #endregion

    #region Handing ErrorTypes
    public static Error Validation(string code, string message) => new(code, message, ErrorType.Validation);
    public static Error Validation(string code, string message, object metaData) => new(code, message, ErrorType.Validation, metaData);
    public static Error UnAuthorized(string code, string message) => new(code, message, ErrorType.Unauthorized);
    public static Error UnAuthorized(string code, string message, object metaData) => new(code, message, ErrorType.Unauthorized, metaData);
    public static Error Forbidden(string code, string message) => new(code, message, ErrorType.Forbidden);
    public static Error Forbidden(string code, string message, object metaData) => new(code, message, ErrorType.Forbidden, metaData);
    public static Error NotFound(string code, string message) => new(code, message, ErrorType.NotFound);
    public static Error NotFound(string code, string message, object metaData) => new(code, message, ErrorType.NotFound, metaData);
    public static Error Conflict(string code, string message) => new(code, message, ErrorType.Conflict);
    public static Error Conflict(string code, string message, object metaData) => new(code, message, ErrorType.Conflict, metaData);
    public static Error Failure(string code, string message) => new(code, message, ErrorType.Failure);
    public static Error Failure(string code, string message, object metaData) => new(code, message, ErrorType.Failure, metaData);
    public static Error UnprocessableEntity(string code, string message) => new(code, message, ErrorType.UnprocessableEntity);
    public static Error UnprocessableEntity(string code, string message, object metaData) => new(code, message, ErrorType.UnprocessableEntity, metaData);
    public static Error TooManyRequests(string code, string message) => new(code, message, ErrorType.TooManyRequests);
    public static Error TooManyRequests(string code, string message, object metaData) => new(code, message, ErrorType.TooManyRequests, metaData);
    public static Error ServiceUnavailable(string code, string message) => new(code, message, ErrorType.ServiceUnavailable);
    public static Error ServiceUnavailable(string code, string message, object metaData) => new(code, message, ErrorType.ServiceUnavailable, metaData);
    #endregion
}
