using Microsoft.EntityFrameworkCore;
using StoreCleanArchitecture.Domain.Entities;

namespace StoreCleanArchitecture.Infrastructure.DbContexts;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
        // Database.EnsureCreated();
    }

    public DbSet<Product> Products { get; init; }
    
    // override protected void OnModelCreating(ModelBuilder builder){
    //     base.OnModelCreating(builder);
    // }
}
