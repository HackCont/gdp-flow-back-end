using FluentResults;
using GdpFlow.API.Models.DTOs.User;
using GdpFlow.API.Models.Entities;

namespace GdpFlow.API.Services.Users;

public interface IUserService
{
	Task<Result> UpdateUserAsync(Guid userId, UpdateDTO updateUserDTO);
	Task<IResult<User>> GetByIdAsync(Guid userId);
}
