using StoreCleanArchitecture.Entities.Domain;

namespace StoreCleanArchitecture.Application.Interfaces.Products;

public interface IProductService
{
    Task<Product?> GetProductAsync(int id);
    Task<ICollection<Product>> GetProductsAsync();
    Task<Product> AddProductAsync(Product product);
}
