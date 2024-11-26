using System.Text.Json.Serialization;

namespace GdpFlow.API.Models.Entities;

public class Moment
{
	public Guid Id { get; set; }
	public DateTime Data { get; set; }
	public required string Title { get; set; }
	public required string Description { get; set; }

	public Guid UserId { get; set; }

	[JsonIgnore]
	public User? User { get; set; }
}
