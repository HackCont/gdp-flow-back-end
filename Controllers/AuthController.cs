using GdpFlow.API.Models.DTOs.User.Login;
using GdpFlow.API.Models.DTOs.User.Register;
using GdpFlow.API.Services.UserServices.Login;
using GdpFlow.API.Services.UserServices.Register;
using Microsoft.AspNetCore.Mvc;

namespace GdpFlow.API.Controllers;
[Route("api/users/")]
[ApiController]
[Produces("application/json")]
public class AuthController : ResultsControllerBase
{
	private readonly IRegisterUserService _registerUserService;
	private readonly ILoginService _loginService;

	public AuthController(IRegisterUserService registerUserService, ILoginService loginService)
	{
		_registerUserService = registerUserService;
		_loginService = loginService;
	}

	[HttpPost]
	[Route("register")]
	public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
	{
		var result = await _registerUserService.RegisterAsync(registerDTO);
		return CustomResult(result);
	}

	[HttpPost]
	[Route("login")]
	public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
	{
		var result = await _loginService.LoginAsync(loginDTO);
		return CustomResult(result);
	}
}
