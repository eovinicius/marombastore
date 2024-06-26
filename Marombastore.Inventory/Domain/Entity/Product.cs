using Marombastore.Core.Seedwork;

namespace Marombastore.Inventory.Domain.Entity;
public class Product : AggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int TotalSold { get; private set; }
    public int TotalQuatity { get; private set; }
    public int ReservedQuatity { get; private set; }

    public int AvailableQuantity => TotalQuatity - ReservedQuatity;

    public DateTime CreatedAt { get; private set; }
    public bool Active { get; private set; } = true;

    public Product(
        string name,
        string description,
        decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
        TotalQuatity = 0;
        CreatedAt = DateTime.Now;
    }

    public void AddQuantity(int quantity)
    {
        throw new NotImplementedException();
    }

    public void RemoveQuantity(int quantity)
    {
        throw new NotImplementedException();
    }

    public void ReserveQuantity(int quantity)
    {
        throw new NotImplementedException();
    }
}
