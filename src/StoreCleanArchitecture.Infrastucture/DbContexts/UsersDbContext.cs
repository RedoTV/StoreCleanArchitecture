using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreCleanArchitecture.Domain.Entities;

namespace StoreCleanArchitecture.Infrastucture.DbContexts;

public class UsersDbContext : IdentityDbContext<User>
{
    public UsersDbContext(DbContextOptions options) : base(options)
    {
    }       

    override protected void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
    }
}
