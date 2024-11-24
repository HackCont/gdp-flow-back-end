using GdpFlow.API.Models.Entities;

namespace GdpFlow.API.Repositories.UserRepository;

public interface IUserRepository : IRepository<User>
{
	Task<User?> GetByEmailAsync(string email);
}
