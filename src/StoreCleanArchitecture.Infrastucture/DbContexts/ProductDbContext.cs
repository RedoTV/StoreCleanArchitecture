using Microsoft.EntityFrameworkCore;
using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Domain.Entities;

namespace StoreCleanArchitecture.Infrastucture.DbContexts;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
        // Database.EnsureCreated();
    }

    public DbSet<Product> Products { get; set; }
    
    // override protected void OnModelCreating(ModelBuilder builder){
    //     base.OnModelCreating(builder);
    // }
}
