using GdpFlow.API.Models.DTOs.User.Register;
using GdpFlow.API.Services.UserServices.Register;
using Microsoft.AspNetCore.Mvc;

namespace GdpFlow.API.Controllers;
[Route("api/users/")]
[ApiController]
[Produces("application/json")]
public class AuthController : ResultsControllerBase
{
	private readonly IRegisterUserService _registerUserService;

	public AuthController(IRegisterUserService registerUserService)
	{
		_registerUserService = registerUserService;
	}

	[HttpPost]
	public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
	{
		var result = await _registerUserService.RegisterAsync(registerDTO);
		return CustomResult(result);
	}
}
