using FluentResults;
using GdpFlow.API.Models.DTOs.Pdi;
using GdpFlow.API.Models.Entities;

namespace GdpFlow.API.Services.Pdis;

public interface IPdiService
{
	Task<Result> UpdateOrCreateAsync(CreatePdiDTO pdiDTO, HttpRequest request);
	Task<Result<Pdi>> GetPdiAsync(Guid userId);
}
