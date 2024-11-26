using GdpFlow.API.Data;
using GdpFlow.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GdpFlow.API.Repositories.UserRepository;

public class UserRepository : Repository<User>, IUserRepository
{
	private readonly AppDbContext _context;

	public UserRepository(AppDbContext context) : base(context)
	{
		_context = context;
	}

	public async Task<User?> GetByEmailAsync(string email)
	{
		return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
	}

	public async Task<User?> GetByIdAsync(Guid userId)
	{
		return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
	}
}
