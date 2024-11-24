using FluentResults;
using GdpFlow.API.Models.DTOs.Pdi;
using System.Security.Claims;

namespace GdpFlow.API.Services.Pdis;

public interface IPdiService
{
	Task<Result> UpdateOrCreateAsync(CreatePdiDTO pdiDTO, HttpRequest request);
}
