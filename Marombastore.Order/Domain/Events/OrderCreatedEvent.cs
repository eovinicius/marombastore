using Marombastore.Core.Seedwork;

namespace Marombastore.Order.Domain.Events;

public class OrderCreatedEvent : IDomainEvent
{
    public Entity.Order Order { get; }
    public DateTime OccurredOn { get; } = DateTime.Now;

    public OrderCreatedEvent(Entity.Order order)
    {
        Order = order;
    }

    public Guid GetAggregateRootId()
    {
        return Order.CustomerId;
    }
}
