namespace GdpFlow.API.Models.Entities;

public class Pdi
{
	public Guid Id { get; set; }
	public string? StartDoing { get; set; }
	public string? StopDoing { get; set; }
	public string? DoLess { get; set; }
	public string? KeepDoing { get; set; }
	public string? DoMore { get; set; }
	public string? Goal { get; set; }
	public DateTime CreatedAt { get; set; }

	public Guid UserId { get; set; }
	public User? User { get; set; }
}
