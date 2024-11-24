using FluentResults;
using GdpFlow.API.Models.DTOs.Moment;

namespace GdpFlow.API.Services.Moments;

public interface IMomentService
{
	Task<Result> CreateAsync(CreateMomentDTO momentDTO);
}
