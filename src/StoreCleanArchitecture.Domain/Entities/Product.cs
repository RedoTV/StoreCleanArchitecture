namespace StoreCleanArchitecture.Domain.Entities;

public class Product
{
    public int? Id { get; set;}
    public required string Name { get; set;}
    public required string Description { get; set; }
    public required string Category { get; set; }
    public double Cost { get; set; }
}
