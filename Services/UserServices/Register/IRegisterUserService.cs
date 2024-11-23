using FluentResults;
using GdpFlow.API.Models.DTOs.User.Register;

namespace GdpFlow.API.Services.UserServices.Register;

public interface IRegisterUserService
{
	Task<Result> RegisterAsync(RegisterDTO registerDTO);
}
