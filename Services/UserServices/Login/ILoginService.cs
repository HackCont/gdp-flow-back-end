using FluentResults;
using GdpFlow.API.Models.DTOs.User.Login;

namespace GdpFlow.API.Services.UserServices.Login;

public interface ILoginService
{
	Task<Result<LoginTokenResponseDTO>> LoginAsync(LoginDTO loginDTO);
}
