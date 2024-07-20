using Microsoft.EntityFrameworkCore;
using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Entities.Domain;

namespace StoreCleanArchitecture.Application.Services.Products;

public class ProductService : IProductService
{
    private readonly IStoreDbContext _productRepository;
    public ProductService(IStoreDbContext productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        await _productRepository.Products.AddAsync(product);
        await _productRepository.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> GetProductAsync(int id)
    {
        return await _productRepository.Products.FindAsync(id);
    } 

    public async Task<ICollection<Product>> GetProductsAsync() => await _productRepository.Products.ToArrayAsync();
}
