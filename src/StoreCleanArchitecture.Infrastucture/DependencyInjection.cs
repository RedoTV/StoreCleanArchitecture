using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Infrastucture.DbContexts;

namespace StoreCleanArchitecture.Infrastucture;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastucture(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        string dbConnection = configuration.GetConnectionString("DbConnection")!;

        services.AddSqlite<ProductDbContext>(dbConnection);

        services.AddScoped<IProductDbContext>(sp => sp.GetRequiredService<ProductDbContext>());

        return services;
    }

    
}