using Microsoft.AspNetCore.Http;

namespace Services.RequestContextAccessorService;

public partial class RequestContextAccessorService : IRequestContextAccessorService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RequestContextAccessorService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
}