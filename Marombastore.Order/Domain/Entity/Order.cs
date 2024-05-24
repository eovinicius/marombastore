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
    public DateTime CreatedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }

    public Order(Guid customerId, List<OrderItem> items)
    {
        CustomerId = customerId;
        Items = items;
        TotalAmount = items.Sum(item => item.TotalPrice());
        Status = EStatusOrder.PendingPayment;
        CreatedAt = DateTime.Now;

        AddDomainEvent(new OrderCreatedEvent(this));
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
}