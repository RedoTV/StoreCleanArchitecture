using Microsoft.EntityFrameworkCore;
using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Entities.Domain;

namespace StoreCleanArchitecture.Infrastucture.DbContexts;

public class ProductDbContext : DbContext, IProductDbContext
{
    public ProductDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Product> Products { get; set; }
    
    override protected void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
    }
}
