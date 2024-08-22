using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Domain.Entities;
using StoreCleanArchitecture.Infrastructure.DbContexts;

namespace StoreCleanArchitecture.Infrastructure.Repositories;

public class ProductRepository(StoreDbContext _storeDbContext) : IProductRepository
{
    public IQueryable<Product> GetAll()
    {
        return _storeDbContext.Products.AsQueryable();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return (await _storeDbContext.Products.FindAsync(id))!;
    }

    public async Task<Product> AddAsync(Product entity)
    {
        await _storeDbContext.Products.AddAsync(entity);
        await _storeDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Product entity)
    {
        _storeDbContext.Products.Update(entity);
        await _storeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product entity)
    {
        _storeDbContext.Products.Remove(entity);
        await _storeDbContext.SaveChangesAsync();
    }
}