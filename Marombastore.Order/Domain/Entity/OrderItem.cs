using Marombastore.Core.Seedwork;

namespace Marombastore.Order.Domain.Entity;

public class OrderItem : EntityBase
{
    public Item Item { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Total { get; private set; }
    public int Quantity { get; private set; }

    public OrderItem(Item item, decimal unitPrice, int quantity)
    {
        Item = item;
        UnitPrice = unitPrice;
        Total = GetTotal();
        Quantity = quantity;

        Validate();
    }

    public decimal GetTotal() => UnitPrice * Quantity;

    private void Validate()
    {
        if (Quantity <= 0) throw new Exception("Quantity must be greater than zero");
    }
}