using System.ComponentModel.DataAnnotations;

namespace GdpFlow.API.Models.DTOs.Pdi;

public class CreatePdiDTO
{
	[StringLength(200, ErrorMessage = "Start Doing can't be longer than 200 characters")]
	public string? StartDoing { get; set; }

	[StringLength(200, ErrorMessage = "Stop Doing can't be longer than 200 characters")]
	public string? StopDoing { get; set; }

	[StringLength(200, ErrorMessage = "Do Less can't be longer than 200 characters")]
	public string? DoLess { get; set; }

	[StringLength(200, ErrorMessage = "Keep Doing can't be longer than 200 characters")]
	public string? KeepDoing { get; set; }

	[StringLength(200, ErrorMessage = "Do More can't be longer than 200 characters")]
	public string? DoMore { get; set; }

	[StringLength(200, ErrorMessage = "Goal can't be longer than 200 characters")]
	public string? Goal { get; set; }

	public Guid UserId { get; set; }
}
