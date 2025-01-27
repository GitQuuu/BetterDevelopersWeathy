using System.ComponentModel.DataAnnotations;

namespace Api.Controllers.AccountController;

public class LoginRequest
{
    /// <summary>
    /// The email registration is also the username
    /// </summary>
    [Required]
    public required string Email { get; set; }
	
    /// <summary>
    /// The user password
    /// </summary>
    [Required]
    public required string Password { get; set; }
}