using System.ComponentModel.DataAnnotations;

namespace StoreCleanArchitecture.Domain.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }
    
    [EmailAddress]
    public required string Email { get; set; } 
    
    public required string Name { get; set; } 
    public required string HashedPassword { get; set; }
    public required string Salt { get; set; } 
    public required IList<string> Roles { get; set; }
}