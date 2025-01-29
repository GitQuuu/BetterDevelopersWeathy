namespace Services.RequestContextAccessorService;

public partial class RequestContextAccessorService
{
    public string? GetReferrer()
    {
        return _httpContextAccessor.HttpContext?.Request.Headers["Referer"].ToString();
    }
}