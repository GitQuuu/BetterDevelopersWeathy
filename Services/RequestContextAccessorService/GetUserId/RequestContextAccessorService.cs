using System.Security.Claims;

namespace Services.RequestContextAccessorService;

public partial class RequestContextAccessorService
{
    public string? GetUserId()
    {
        return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}