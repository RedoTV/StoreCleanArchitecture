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
    public ICollection<Product> GetProducts() => _productRepository.Products.ToArray();
    public async Task<ICollection<Product>> GetProductsAsync() => await _productRepository.Products.ToArrayAsync();
}
