using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using StoreCleanArchitecture.Application.Interfaces.Auth;
using StoreCleanArchitecture.Application.Interfaces.Email;
using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Infrastucture.DbContexts;
using StoreCleanArchitecture.Infrastucture.Repositories;
using StoreCleanArchitecture.Infrastucture.Services;

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

        services.AddTransient<IEmailSender, EmailSender>();

        string storeDbConnection = configuration.GetConnectionString("StoreDbConnection")!;
        services.AddDbContext<ProductDbContext>(opts => {
            opts.UseSqlite(storeDbConnection);
        });
        services.AddTransient<IProductRepository, ProductRepository>();

        string usersDbConnection = configuration.GetConnectionString("UsersDbConnection")!;
        services.AddDbContext<UsersDbContext>(opts => {
            opts.UseSqlite(usersDbConnection);
        });
        
        services.AddAuthorization();

        services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
        
        services.AddTransient<IAuthService,AuthService>();
        
        return services;
    }
}