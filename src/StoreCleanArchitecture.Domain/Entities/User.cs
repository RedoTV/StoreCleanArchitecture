namespace StoreCleanArchitecture.Domain.Entities;

public record User(Guid Id, string Name, string Email, string HashedPassword, string[] Roles);