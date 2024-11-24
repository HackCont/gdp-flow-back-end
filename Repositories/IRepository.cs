﻿namespace GdpFlow.API.Repositories;

public interface IRepository<T> where T : class
{
	Task<IEnumerable<T>> GetAllAsync();
	Task<bool> AddAsync(T entity);
	Task<bool> UpdateAsync(T entity);
	void Delete(T entity);
}
