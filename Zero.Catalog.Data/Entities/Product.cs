using System.Security.Cryptography;

namespace Zero.Catalog.Data.Entities;

public record Product
{
    public Guid Id { get; private init; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; } = 0;
    public DateTime CreatedAt { get; private init; }
    public DateTime UpdatedAt { get; private set; }

    private Product(Guid id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
        CreatedAt = DateTime.UtcNow;
    }

    public static Product Create(Guid id, string name, decimal price)
    {
        return new Product(id, name, price);
    }

    public void ChangeDescription(string description)
    {
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }
}
