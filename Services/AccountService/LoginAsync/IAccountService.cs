namespace Services.AccountService;

public partial interface IAccountService
{
    Task<ServiceResult<LoginResponseDto>> LoginAsync(LoginRequestDto dto);
}