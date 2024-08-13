namespace StoreCleanArchitecture.Application.Interfaces.Generic;

public interface IGenericRepository<T> where T : class
{
    public IQueryable<T> GetAll();
    public Task<T> GetByIdAsync(int id);
    public Task<T> AddAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(T entity);
}