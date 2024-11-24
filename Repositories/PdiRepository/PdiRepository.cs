using GdpFlow.API.Data;
using GdpFlow.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GdpFlow.API.Repositories.PdiRepository;

public class PdiRepository : Repository<Pdi>, IPdiRepository
{
	private readonly AppDbContext _context;

	public PdiRepository(AppDbContext context) : base(context)
	{
		_context = context;
	}

	public async Task<Pdi?> GetByIdAsync(Guid pdiId)
	{
		return await _context.Pdis.FirstOrDefaultAsync(p => p.Id == pdiId);
	}

}
