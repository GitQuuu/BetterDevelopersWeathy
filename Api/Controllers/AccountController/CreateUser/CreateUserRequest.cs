using System.ComponentModel.DataAnnotations;

namespace Api.Controllers.AccountController;

/// <summary>
/// Request model to create a user
/// </summary>
public class CreateUserRequest
{
    [EmailAddress]
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string PasswordConfirm { get; set; }
}