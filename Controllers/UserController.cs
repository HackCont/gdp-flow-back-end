using GdpFlow.API.Models.DTOs.User;
using GdpFlow.API.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GdpFlow.API.Controllers;
[Route("api/users")]
[ApiController]
public class UserController : ResultsControllerBase
{
	private readonly IUserService _userService;

	public UserController(IUserService userService)
	{
		_userService = userService;
	}

	[HttpPut("{userId}")]
	[Authorize]
	public async Task<IActionResult> Update(Guid userId, UpdateDTO updateDTO)
	{
		var result = await _userService.UpdateUserAsync(userId, updateDTO);
		return CustomResult(result);
	}

	[HttpGet("{userId}")]
	[Authorize]
	public async Task<IActionResult> GetById(Guid userId)
	{
		var result = await _userService.GetByIdAsync(userId);
		return CustomResult(result);
	}
}
