using FluentResults;
using GdpFlow.API.Models.DTOs.Moment;
using GdpFlow.API.Models.Entities;

namespace GdpFlow.API.Services.Moments;

public interface IMomentService
{
	Task<Result> CreateAsync(CreateMomentDTO momentDTO);
	Task<IResult<IEnumerable<Moment>>> GetAllMomentsAsync(Guid userId);
}
