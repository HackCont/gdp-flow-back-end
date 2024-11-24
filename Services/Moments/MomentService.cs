using FluentResults;
using GdpFlow.API.Models.DTOs.Moment;
using GdpFlow.API.Models.Entities;
using GdpFlow.API.Models.Results;
using GdpFlow.API.Repositories.MomentRepository;

namespace GdpFlow.API.Services.Moments;

public class MomentService : IMomentService
{
	private readonly IMomentRepository _momentRepository;

	public MomentService(IMomentRepository momentRepository)
	{
		_momentRepository = momentRepository;
	}

	public async Task<Result> CreateAsync(CreateMomentDTO momentDTO)
	{
		var moment = new Moment
		{
			Data = momentDTO.Data,
			Title = momentDTO.Title,
			Description = momentDTO.Description,
			UserId = momentDTO.UserId,
		};

		var momentRegistered = await _momentRepository.AddAsync(moment);
		if (!momentRegistered)
		{
			return Result.Fail(new CustomError("Error creating moment in database", StatusCodes.Status500InternalServerError));
		}

		return Result.Ok().WithSuccess(new CustomSuccess("Moment registered successfully", StatusCodes.Status201Created));
	}
}
