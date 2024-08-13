using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Domain.Entities;
using StoreCleanArchitecture.Infrastucture.DbContexts;

namespace StoreCleanArchitecture.Infrastucture.Repositories;

public class ProductRepository(ProductDbContext productDbContext) : IProductRepository
{
    public IQueryable<Product> GetAll()
    {
        return productDbContext.Products.AsQueryable();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return (await productDbContext.Products.FindAsync(id))!;
    }

    public async Task<Product> AddAsync(Product entity)
    {
        await productDbContext.Products.AddAsync(entity);
        await productDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Product entity)
    {
        productDbContext.Products.Update(entity);
        await productDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product entity)
    {
        productDbContext.Products.Remove(entity);
        await productDbContext.SaveChangesAsync();
    }
}