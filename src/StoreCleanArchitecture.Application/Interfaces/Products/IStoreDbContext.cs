using Microsoft.EntityFrameworkCore;
using StoreCleanArchitecture.Entities.Domain;

namespace StoreCleanArchitecture.Application.Interfaces.Products;

public interface IStoreDbContext
{
    DbSet<Product> Products { get; set;}
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
