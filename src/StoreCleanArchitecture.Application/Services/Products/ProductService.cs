using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Domain.Entities;

namespace StoreCleanArchitecture.Application.Services.Products;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<Product> AddProductAsync(Product product)
    {
        await productRepository.AddAsync(product);
        return product;
    }

    public async Task<Product?> GetProductAsync(int id)
    {
        return await productRepository.GetByIdAsync(id);
    } 

    public Product[] GetProducts() => productRepository.GetAll().ToArray();
}