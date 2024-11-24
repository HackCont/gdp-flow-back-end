using GdpFlow.API.Models.DTOs.User;
using GdpFlow.API.Services.Users;
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
	public async Task<IActionResult> Update(Guid userId, UpdateDTO updateDTO)
	{
		var result = await _userService.UpdateUserAsync(userId, updateDTO);
		return CustomResult(result);
	}
}
