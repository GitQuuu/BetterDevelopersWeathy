namespace Api.Controllers.AccountController;

public class CreateUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
}