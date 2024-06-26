namespace StoreCleanArchitecture.Entities.Domain;

public class Product
{
    public int? Id { get; set;}
    public string Name { get; set;} = null!;
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public double Cost { get; set; }
}
