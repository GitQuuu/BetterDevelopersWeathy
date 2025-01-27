using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;

namespace Services.AccountService;

public partial class AccountBll : ControllerBase, IAccountBll
{
    private readonly IAccountService _accountService;
    private readonly IResponseService _responseService;

    public AccountBll(IAccountService  accountService, IResponseService responseService)
    {
        _accountService = accountService;
        _responseService = responseService;
    }
}