namespace GdpFlow.API.Models.Entities;

public class User
{
	public Guid Id { get; set; }
	public required string Email { get; set; }
	public required string FirstName { get; set; }
	public required string LastName { get; set; }
	public string? Phone { get; set; }
	public string? Bio { get; set; }
	public string? Skills { get; set; }
	public DateTime CreatedAt { get; set; }
}
