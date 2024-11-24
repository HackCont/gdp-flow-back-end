using System.ComponentModel.DataAnnotations;

namespace GdpFlow.API.Models.DTOs.User.Login;

public class LoginDTO
{
	[Required(ErrorMessage = "Email is required")]
	[EmailAddress(ErrorMessage = "Invalid email address")]
	public required string Email { get; set; }

	[Required(ErrorMessage = "Password is required")]
	[StringLength(12, MinimumLength = 5, ErrorMessage = "Password must be at least 5 characters long")]
	public required string Password { get; set; }
}
