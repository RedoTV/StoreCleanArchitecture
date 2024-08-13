using Microsoft.EntityFrameworkCore;
using StoreCleanArchitecture.Domain.Entities;

namespace StoreCleanArchitecture.Infrastructure.DbContexts;

public class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions options) : base(options)
    {
        //Database.EnsureCreated();
    }    
    
    public DbSet<User> Users { get; set; }

    // override protected void OnModelCreating(ModelBuilder builder){
    //     base.OnModelCreating(builder);
    // }
}
