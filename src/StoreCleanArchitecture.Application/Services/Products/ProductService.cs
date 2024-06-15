using Microsoft.EntityFrameworkCore;
using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Entities.Domain;

namespace StoreCleanArchitecture.Application.Services.Products;

public class ProductService : IProductService
{
    private readonly IProductDbContext _productRepository;
    public ProductService(IProductDbContext productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> GetProductAsync(int id)
    {
        return await _productRepository.Products.FindAsync(id);
    } 

    public async Task<ICollection<Product>> GetProductsAsync() => await _productRepository.Products.ToArrayAsync();
}
