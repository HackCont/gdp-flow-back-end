using GdpFlow.API.Models.DTOs.Moment;
using GdpFlow.API.Services.Moments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GdpFlow.API.Controllers;
[Route("api/moment")]
[ApiController]
public class MomentController : ResultsControllerBase
{
	private readonly IMomentService _momentService;

	public MomentController(IMomentService momentService)
	{
		_momentService = momentService;
	}

	[HttpPost]
	[Authorize]
	public async Task<IActionResult> Create([FromBody] CreateMomentDTO momentDTO)
	{
		var result = await _momentService.CreateAsync(momentDTO);
		return CustomResult(result);
	}

	[HttpGet("{userId}")]
	[Authorize]
	public async Task<IActionResult> GetAllMoment(Guid userId)
	{
		var result = await _momentService.GetAllMomentsAsync(userId);
		return CustomResult(result);
	}
}
