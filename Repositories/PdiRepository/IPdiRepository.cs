using GdpFlow.API.Models.Entities;

namespace GdpFlow.API.Repositories.PdiRepository;

public interface IPdiRepository : IRepository<Pdi>
{
	Task<Pdi?> GetByIdAsync(Guid pdiId);
}
