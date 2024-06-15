using Ardalis.Specification.EntityFrameworkCore;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Entities.Domain;


namespace StoreCleanArchitecture.Application.GraphQL.Queries;

public class ProductQuery
{
    public async Task<Product?> GetProduct([Service] IProductService productService, string productName)
    {
        return (await productService.GetProductsAsync()).FirstOrDefault(p => p.Name == productName);
    }
    public async Task<ICollection<Product>> GetAllProducts([Service] IProductService productService)
    {
        return await productService.GetProductsAsync();
    }
}
