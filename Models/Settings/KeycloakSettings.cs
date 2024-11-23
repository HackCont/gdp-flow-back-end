namespace GdpFlow.API.Models.Settings;

public class KeycloakSettings
{
	public required string Authority { get; set; }
	public required string Audience { get; set; }
	public required bool RequireHttpsMetadata { get; set; }
	public required string ClientId { get; set; }
	public required string ClientSecret { get; set; }
	public required KeycloakUri Uri { get; set; }
}

public class KeycloakUri
{
	public required string Register { get; set; }
	public required string Login { get; set; }
}
