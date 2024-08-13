using Microsoft.Extensions.DependencyInjection;
using StoreCleanArchitecture.Application.Interfaces.Products;

using StoreCleanArchitecture.Application.Services.Products;

namespace StoreCleanArchitecture.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();
        
        return services;
    }
}