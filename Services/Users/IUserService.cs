using FluentResults;
using GdpFlow.API.Models.DTOs.User;

namespace GdpFlow.API.Services.Users;

public interface IUserService
{
	Task<Result> UpdateUserAsync(Guid userId, UpdateDTO updateUserDTO);
}
