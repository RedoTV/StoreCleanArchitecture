using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using StoreCleanArchitecture.Application.Interfaces.Auth;
using StoreCleanArchitecture.Application.Interfaces.Email;
using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Application.Mapper;
using StoreCleanArchitecture.Infrastructure.DbContexts;
using StoreCleanArchitecture.Infrastructure.Repositories;
using StoreCleanArchitecture.Infrastructure.Services;

namespace StoreCleanArchitecture.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.Seq("http://localhost:5341")
            .CreateLogger();
        
        services.AddSerilog();

        services.AddAutoMapper(typeof(UserProfile));
        services.AddTransient<IEmailSender, EmailSender>();

        string productsDbConnection = configuration.GetConnectionString("StoreDbConnection")!;
        services.AddDbContext<StoreDbContext>(opts => {
            opts.UseSqlite(
                productsDbConnection, 
                b => b.MigrationsAssembly("StoreCleanArchitecture.API")
            );
        });
        services.AddTransient<IProductRepository, ProductRepository>();

        string usersDbConnection = configuration.GetConnectionString("UsersDbConnection")!;
        services.AddDbContext<UsersDbContext>(opts =>
        {
            opts.UseSqlite(
                usersDbConnection, 
                b => b.MigrationsAssembly("StoreCleanArchitecture.API")
            );
        });
        
        services.AddAuthorization();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)),
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });
        
        services.AddTransient<IAuthService,AuthService>();
        
        return services;
    }
}