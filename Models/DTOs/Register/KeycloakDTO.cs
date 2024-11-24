namespace GdpFlow.API.Models.DTOs.Register;

public class KeycloakDTO
{
	public required string Email { get; set; }
	public required string FirstName { get; set; }
	public required string LastName { get; set; }
	public bool Enabled { get; set; }
	public bool EmailVerified { get; set; }
	public required List<CredentialDTO> Credentials { get; set; }
}

public class CredentialDTO
{
	public required string Type { get; set; }
	public required string Value { get; set; }
	public bool Temporary { get; set; }
}
