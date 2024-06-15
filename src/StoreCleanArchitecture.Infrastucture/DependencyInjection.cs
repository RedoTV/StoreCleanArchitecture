using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Infrastucture.DbContexts;

namespace StoreCleanArchitecture.Infrastucture;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastucture(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddSerilog((services, lc) => lc
            .ReadFrom.Configuration(configuration)
            .ReadFrom.Services(services)
            .Enrich.FromLogContext()
            .WriteTo.Console()
        );

        string dbConnection = configuration.GetConnectionString("DbConnection")!;

        services.AddSqlite<ProductDbContext>(dbConnection);

        services.AddScoped<IProductDbContext>(sp => sp.GetRequiredService<ProductDbContext>());

        return services;
    }

    
}