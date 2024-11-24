using GdpFlow.API.Data;
using Microsoft.EntityFrameworkCore;

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

	public async Task<IEnumerable<T>> GetAllAsync()
	{
		return await _dbSet.ToListAsync();
	}

	public async Task<T> GetByIdAsync(int id)
	{
		return await _dbSet.FindAsync(id);
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

	public void Delete(T entity)
	{
		_dbSet.Remove(entity);
		_context.SaveChanges();
	}
}
