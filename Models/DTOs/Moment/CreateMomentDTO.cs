using System.ComponentModel.DataAnnotations;

namespace GdpFlow.API.Models.DTOs.Moment;

public class CreateMomentDTO
{
	public DateTime Data { get; set; }

	[Required(ErrorMessage = "Title is required")]
	[StringLength(20, ErrorMessage = "Title can't be longer than 20 characters")]
	public required string Title { get; set; }

	[Required(ErrorMessage = "Description is required")]
	[StringLength(50, ErrorMessage = "Description can't be longer than 50 characters")]
	public required string Description { get; set; }

	public Guid UserId { get; set; }
}
