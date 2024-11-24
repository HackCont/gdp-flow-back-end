using FluentResults;
using GdpFlow.API.Models.DTOs.User;
using GdpFlow.API.Models.Entities;
using GdpFlow.API.Models.Results;
using GdpFlow.API.Repositories.UserRepository;

namespace GdpFlow.API.Services.Users;

public class UserService : IUserService
{
	public readonly IUserRepository _userRepository;

	public UserService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<Result> UpdateUserAsync(Guid userId, UpdateDTO updateUserDTO)
	{
		var existingUser = await _userRepository.GetByEmailAsync(updateUserDTO.Email);
		if (existingUser == null)
		{
			return Result.Fail(new CustomError("User not found", StatusCodes.Status404NotFound));
		}

		if (userId != existingUser.Id)
		{
			return Result.Fail(new CustomError("The user ID in the URL does not match the ID in the request body.", StatusCodes.Status400BadRequest));
		}

		existingUser.FirstName = updateUserDTO.FirstName;
		existingUser.LastName = updateUserDTO.LastName;
		existingUser.Phone = updateUserDTO?.Phone;
		existingUser.Bio = updateUserDTO?.Bio;
		existingUser.Skills = updateUserDTO?.Skills;

		var userUpdated = await _userRepository.UpdateAsync(existingUser);
		if (!userUpdated)
		{
			return Result.Fail(new CustomError("Error updating user in database", StatusCodes.Status500InternalServerError));
		}

		return Result.Ok().WithSuccess(new CustomSuccess("User updated successfully", StatusCodes.Status200OK));
	}

	public async Task<IResult<User>> GetByIdAsync(Guid userId)
	{
		var existingUser = await _userRepository.GetByIdAsync(userId);
		if (existingUser == null)
		{
			return Result.Fail<User>(new CustomError("User not found", StatusCodes.Status404NotFound));
		}

		return Result.Ok(existingUser);
	}
}
