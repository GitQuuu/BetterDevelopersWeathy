namespace Services.RequestContextAccessorService;

public partial interface IRequestContextAccessorService
{
    string? GetUserId();
}