using System.Runtime.CompilerServices;
using Marombastore.Core.Seedwork;
using Marombastore.Order.Domain.Enum;
using Marombastore.Order.Domain.Events;

namespace Marombastore.Order.Domain.Entity;

public class Order : AggregateRoot
{
    public Guid CustomerId { get; private set; }
    public List<OrderItem> Items { get; private set; }
    public decimal TotalAmount { get; private set; }
    public EStatusOrder Status { get; private set; }
    public DateTime? FinishedAt { get; private set; }

    public Order(Guid customerId)
    {
        CustomerId = customerId;
        Items = [];
        TotalAmount = 0;
        Status = EStatusOrder.PendingPayment;

        AddDomainEvent(new OrderCreatedEvent(this));
    }
    public void AddItem(Item item, int quantity)
    {
        Items.Add(new OrderItem(item, item.Price, quantity));
        TotalAmount += item.Price * quantity;
    }

    public void PaymentConfirmed()
    {
        if (Status == EStatusOrder.PendingPayment)
        {
            Status = EStatusOrder.PaymentConfirmed;
        }

        // AddDomainEvent(new OrderPaymentConfirmedEvent(this));
    }

    public void Canceled()
    {
        if (Status == EStatusOrder.PendingPayment)
        {
            Status = EStatusOrder.Canceled;
        }
    }

    public void Finished()
    {
        if (Status == EStatusOrder.PaymentConfirmed)
        {
            Status = EStatusOrder.Finished;
        }
    }

    public void GetTotal() => TotalAmount = Items.Sum(item => item.GetTotal());
}