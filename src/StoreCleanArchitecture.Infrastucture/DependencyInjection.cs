using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

        var signingKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("B1G0EsWG26THMXhY08dPRdSHvzMZO65I"));

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidIssuer = "http://localhost:5000/",
                        ValidAudience = "http://localhost:4200/",
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey
                    };
            });

        return services;
    }

    
}