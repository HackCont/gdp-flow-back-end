using System.Text.Json.Serialization;

namespace GdpFlow.API.Models.DTOs.User.Register;

public class AdminTokenResponseDTO
{
	[JsonPropertyName("access_token")]
	public string? AccessToken { get; set; }
}
