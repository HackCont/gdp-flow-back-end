using FluentResults;
using GdpFlow.API.Models.DTOs.Login;

namespace GdpFlow.API.Services.Login;

public interface ILoginService
{
	Task<Result<LoginTokenResponseDTO>> LoginAsync(LoginDTO loginDTO);
}
