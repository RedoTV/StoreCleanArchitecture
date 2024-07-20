using Microsoft.EntityFrameworkCore;
using StoreCleanArchitecture.Application.Interfaces.Products;
using StoreCleanArchitecture.Entities.Domain;

namespace StoreCleanArchitecture.Infrastucture.DbContexts;

public class StoreDbContext : DbContext, IStoreDbContext
{
    public StoreDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    
    override protected void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
    }
}
