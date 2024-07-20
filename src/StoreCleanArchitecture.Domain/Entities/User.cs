using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace StoreCleanArchitecture.Domain.Entities;

public class User : IdentityUser
{
    [MaxLength(30)]
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty; 
    
    [Required]
    public string Phone { get; set; } = string.Empty;
}