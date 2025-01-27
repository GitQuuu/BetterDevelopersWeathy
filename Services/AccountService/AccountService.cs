using Services.UserManagerService;

namespace Services.AccountService;

public partial class AccountService : IAccountService
{
    private readonly IUserManagerService _userManagerService;

    public AccountService(IUserManagerService userManagerService)
    {
        _userManagerService = userManagerService;
    }
}