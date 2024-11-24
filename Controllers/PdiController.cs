using GdpFlow.API.Models.DTOs.Pdi;
using GdpFlow.API.Services.Pdis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GdpFlow.API.Controllers;
[Route("api/pdi")]
[ApiController]
public class PdiController : ResultsControllerBase
{
	private readonly IPdiService _pdiService;

	public PdiController(IPdiService pdiService)
	{
		_pdiService = pdiService;
	}

	[HttpPut]
	[Authorize]
	public async Task<IActionResult> UpdateOrCreate([FromBody] CreatePdiDTO createPdiDTO)
	{
		var result = await _pdiService.UpdateOrCreateAsync(createPdiDTO, Request);
		return CustomResult(result);
	}
}
