using System.ComponentModel.DataAnnotations;

namespace GdpFlow.API.Models.DTOs.User.Register;

public class RegisterDTO
{
	[Required(ErrorMessage = "Email is required")]
	[EmailAddress(ErrorMessage = "Invalid email address")]
	public required string Email { get; set; }

	[Required(ErrorMessage = "First name is required")]
	[StringLength(20, ErrorMessage = "First name can't be longer than 20 characters")]
	public required string FirstName { get; set; }

	[Required(ErrorMessage = "Last name is required")]
	[StringLength(30, ErrorMessage = "Last name can't be longer than 30 characters")]
	public required string LastName { get; set; }

	[Required(ErrorMessage = "Password is required")]
	[StringLength(100, MinimumLength = 5, ErrorMessage = "Password must be at least 6 characters long")]
	public required string Password { get; set; }
}