using FluentResults;
using GdpFlow.API.Models.DTOs.Pdi;
using GdpFlow.API.Models.Entities;
using GdpFlow.API.Models.Results;
using GdpFlow.API.Repositories.PdiRepository;

namespace GdpFlow.API.Services.Pdis;

public class PdiService : IPdiService
{
	private readonly IPdiRepository _pdiRepository;

	public PdiService(IPdiRepository pdiRepository)
	{
		_pdiRepository = pdiRepository;
	}

	public async Task<Result> UpdateOrCreateAsync(CreatePdiDTO pdiDTO, HttpRequest request)
	{
		if (!request.Headers.TryGetValue("pdiId", out var pdiId))
		{
			var pdiCreated = await CreateAsync(pdiDTO);
			if (!pdiCreated)
			{
				return Result.Fail(new CustomError("Error creating pdi in database", StatusCodes.Status500InternalServerError));
			}

			return Result.Ok().WithSuccess(new CustomSuccess("Pdi registered successfully", StatusCodes.Status201Created));
		}

		var id = Guid.Parse(pdiId!);
		var existingPdi = await _pdiRepository.GetByIdAsync(id);
		if (existingPdi == null)
		{
			return Result.Fail(new CustomError("Pdi not found", StatusCodes.Status404NotFound));
		}

		existingPdi.StartDoing = pdiDTO?.StartDoing;
		existingPdi.StopDoing = pdiDTO?.StopDoing;
		existingPdi.DoLess = pdiDTO?.DoLess;
		existingPdi.KeepDoing = pdiDTO?.KeepDoing;
		existingPdi.DoMore = pdiDTO?.DoMore;
		existingPdi.Goal = pdiDTO?.Goal;

		var pdiUpdated = await _pdiRepository.UpdateAsync(existingPdi);
		if (!pdiUpdated)
		{
			return Result.Fail(new CustomError("Error updating pdi in database", StatusCodes.Status500InternalServerError));
		}

		return Result.Ok().WithSuccess(new CustomSuccess("PDI updated successfully", StatusCodes.Status200OK));
	}

	private async Task<bool> CreateAsync(CreatePdiDTO pdiDTO)
	{
		var pdi = new Pdi
		{
			StartDoing = pdiDTO.StartDoing,
			StopDoing = pdiDTO.StopDoing,
			DoLess = pdiDTO.DoLess,
			KeepDoing = pdiDTO.KeepDoing,
			DoMore = pdiDTO.DoMore,
			Goal = pdiDTO.Goal,
			UserId = pdiDTO.UserId,
		};

		var pdiRegistered = await _pdiRepository.AddAsync(pdi);
		return pdiRegistered;
	}
}
