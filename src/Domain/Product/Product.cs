namespace OrderWebAPI.Domain.Product;

public class Product : Entity
{
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool Stock { get; set; }
    public Category Category { get; set; }
}
