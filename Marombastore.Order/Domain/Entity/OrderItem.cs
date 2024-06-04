using Marombastore.Core.Seedwork;

namespace Marombastore.Order.Domain.Entity;

public class OrderItem : EntityBase
{
    public Item Item { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public OrderItem(Item item, decimal price, int quantity)
    {
        Item = item;
        Price = price;
        Quantity = quantity;
    }

    public decimal GetTotal() => Item.Price * Quantity;

    private void Validate()
    {
        if (Quantity <= 0) throw new Exception("Quantity must be greater than zero");
    }
}