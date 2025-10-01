namespace InsuranceCalculator.Shared.Result;

public enum ErrorType
{
    [Description("No Warning and Error")]
    None = 100,

    [Description("Bad Request")]
    Validation = 400,

    [Description("Unauthorized")]
    Unauthorized = 401,

    [Description("Forbidden")]
    Forbidden = 403,

    [Description("Not Found")]
    NotFound = 404,

    [Description("Conflict")]
    Conflict = 409,

    [Description("Internal Server Error")]
    Failure = 500,

    [Description("Unprocessable Entity ")]
    UnprocessableEntity = 422,

    [Description("Too Many Requests")]
    TooManyRequests = 429,

    [Description("Service Unavailable")]
    ServiceUnavailable = 503
}
