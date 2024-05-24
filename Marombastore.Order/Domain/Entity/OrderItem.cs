using Marombastore.Core.Seedwork;

namespace Marombastore.Order.Domain.Entity;

public class OrderItem : EntityBase
{
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    public OrderItem(Guid productId, int quantity, decimal price)
    {
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    public decimal TotalPrice() => Quantity * Price;

}