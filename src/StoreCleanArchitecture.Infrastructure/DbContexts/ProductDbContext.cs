using Microsoft.EntityFrameworkCore;
using StoreCleanArchitecture.Domain.Entities;

namespace StoreCleanArchitecture.Infrastructure.DbContexts;

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
