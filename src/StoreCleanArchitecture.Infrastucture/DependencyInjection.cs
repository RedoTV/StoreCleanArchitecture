using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Domain.Entities;
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

        string storeDbConnection = configuration.GetConnectionString("StoreDbConnection")!;
        services.AddSqlite<StoreDbContext>(storeDbConnection);
        services.AddScoped<IStoreDbContext>(sp => sp.GetRequiredService<StoreDbContext>());

        string usersDbConnection = configuration.GetConnectionString("UsersDbConnection")!;
        services.AddSqlite<UsersDbContext>(usersDbConnection);
        
        services.AddAuthorization();

        services.AddIdentityApiEndpoints<User>().
            AddEntityFrameworkStores<UsersDbContext>();

        return services;
    }

    
}