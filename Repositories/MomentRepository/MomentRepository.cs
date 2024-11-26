using GdpFlow.API.Data;
using GdpFlow.API.Models.Entities;

namespace GdpFlow.API.Repositories.MomentRepository;

public class MomentRepository : Repository<Moment>, IMomentRepository
{
	private readonly AppDbContext _context;

	public MomentRepository(AppDbContext context) : base(context)
	{
		_context = context;
	}
}
