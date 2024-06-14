using StoreCleanArchitecture.Entities.Domain;

namespace StoreCleanArchitecture.Application.Interfaces.Products;

public interface IProductService
{
    ICollection<Product> GetProducts();
    Task<ICollection<Product>> GetProductsAsync();
}
