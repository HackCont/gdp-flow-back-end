using GdpFlow.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GdpFlow.API.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
	private readonly AppDbContext _context;
	private readonly DbSet<T> _dbSet;

	public Repository(AppDbContext context)
	{
		_context = context;
		_dbSet = _context.Set<T>();
	}

	public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
	{
		var query = _dbSet.AsNoTracking();

		if (predicate != null)
		{
			query = query.Where(predicate);
		}

		return await query.ToListAsync();
	}


	public async Task<bool> AddAsync(T entity)
	{
		try
		{
			await _dbSet.AddAsync(entity);
			var affectedRows = await _context.SaveChangesAsync();
			return affectedRows > 0;
		}
		catch (Exception)
		{

			return false;
		}
	}

	public async Task<bool> UpdateAsync(T entity)
	{
		try
		{
			_dbSet.Update(entity);
			var affectedRows = await _context.SaveChangesAsync();
			return affectedRows > 0;
		}
		catch (Exception)
		{

			return false;
		}
	}
}
