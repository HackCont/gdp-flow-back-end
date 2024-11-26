using System.Linq.Expressions;

namespace GdpFlow.API.Repositories;

public interface IRepository<T> where T : class
{
	Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
	Task<bool> AddAsync(T entity);
	Task<bool> UpdateAsync(T entity);
}
;