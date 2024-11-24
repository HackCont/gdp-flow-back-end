using System.ComponentModel.DataAnnotations;

namespace GdpFlow.API.Models.DTOs.User;

public class UpdateDTO
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

	public string? Phone { get; set; }

	public string? Skills { get; set; }

	[StringLength(300, ErrorMessage = "Bio can't be longer than 300 characters")]
	public string? Bio { get; set; }
}
