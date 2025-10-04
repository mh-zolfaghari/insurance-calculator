using InsuranceCalculator.Shared.Abstraction.Commons;

namespace InsuranceCalculator.Api.Services;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : ICurrentUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private bool _isInitialized = false;

    public Guid Token
    {
        get
        {
            var token = _httpContextAccessor.HttpContext?.Request?.Headers["Token"];
            return token is not null && Guid.TryParse(token, out var _token) ? _token : Guid.Empty;
        }
    }

    public Guid? UserId { get; private set; }
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }

    public void Initialize
        (
            Guid userId,
            string? firstName,
            string? lastName
        )
    {
        if (_isInitialized)
            throw new ApplicationException("Current user is already initialized.");

        UserId = userId;
        FirstName = firstName;
        LastName = lastName;

        _isInitialized = true;
    }
}
