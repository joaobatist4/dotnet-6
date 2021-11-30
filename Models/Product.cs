namespace Dotnet6.Models;

public class Product
{
    public Guid Id { get; init; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Quantity { get; private set; }
    public DateTime CreationDate { get; set; }
    //como serializar DateOnly

    public Product CreateProduct(string name, string description, decimal quantity)
        => new ()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Quantity = quantity,
            CreationDate = DateTime.Now
        };


    public Product SetQuantity(decimal quantity)
    {
        Quantity = quantity;
        return this;
    }

}

