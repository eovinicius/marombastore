using Marombastore.Core.Seedwork;

namespace Marombastore.Order.Domain.Entity;

public class Item : AggregateRoot
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; private set; }
    public Item(string name, decimal price, string description)
    {
        Name = name;
        Price = price;
        Description = description;
    }
}