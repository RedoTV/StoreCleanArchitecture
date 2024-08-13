using StoreCleanArchitecture.Domain.Entities;

namespace StoreCleanArchitecture.Application.Interfaces.Products;

public interface IProductService
{
    Task<Product?> GetProductAsync(int id);
    Product[] GetProducts();
    Task<Product> AddProductAsync(Product product);
}
