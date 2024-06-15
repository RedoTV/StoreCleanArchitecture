using Ardalis.Specification.EntityFrameworkCore;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Entities.Domain;

namespace StoreCleanArchitecture.Application.GraphQL;

public class Query
{
    private readonly ILogger<Query> _logger;
    public Query(ILogger<Query> logger)
    {
        _logger = logger;
    }

    public async Task<Product?> GetProduct([Service] IProductService productService, int id)
    {
        Product? product = await productService.GetProductAsync(id);
        if (product == null)
            _logger.LogWarning($"Doesn't find product with id : {id}");
        
        return product;
    }
    public async Task<ICollection<Product>> GetAllProducts([Service] IProductService productService)
    {
        return await productService.GetProductsAsync();
    }

    
}
