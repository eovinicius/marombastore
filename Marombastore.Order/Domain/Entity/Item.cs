using Marombastore.Core.Seedwork;

namespace Marombastore.Order.Domain.Entity;

public class Item : AggregateRoot
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; private set; }
    public bool Active { get; private set; }

    public Item(string name, decimal price, string description, bool active)
    {
        Name = name;
        Price = price;
        Description = description;
        Active = active;
    }

    public void Activate()
    {
        if (!Active) Active = true;
    }

    public void Deactivate()
    {
        if (Active) Active = false;
    }

    public void ChangePrice(decimal price)
    {
        if (price <= 0) throw new Exception("Price must be greater than zero");
        Price = price;
    }

    public void ChangeDescription(string description)
    {
        Description = description;
    }
}