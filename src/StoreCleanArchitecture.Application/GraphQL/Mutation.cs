using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Entities.Domain;

namespace StoreCleanArchitecture.Application.GraphQL;

public class Mutation
{
    public async Task<Product> AddProduct([Service] IProductService productService, Product product)
    {
        return await productService.AddProductAsync(product);
    }
}
