using FluentResults;
using GdpFlow.API.Models.DTOs.Register;

namespace GdpFlow.API.Services.Register;

public interface IRegisterUserService
{
	Task<Result> RegisterAsync(RegisterDTO registerDTO);
}
