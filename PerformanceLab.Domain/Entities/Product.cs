namespace PerformanceLab.Domain.Entities;

public sealed class Product
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public decimal Price { get; private set; }

    public int Stock { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private Product()
    {
        Name = string.Empty;
    }

    public Product(
        string name,
        string? description,
        decimal price,
        int stock)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(
        string name,
        string? description,
        decimal price,
        int stock)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }
}