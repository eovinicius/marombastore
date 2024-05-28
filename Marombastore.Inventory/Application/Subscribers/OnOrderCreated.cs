using Marombastore.Core.Seedwork;
using Marombastore.Inventory.Application.UseCases;
using Marombastore.Order.Domain.Events;
using EventHandler = Marombastore.Core.Seedwork.EventHandler;

namespace Marombastore.Inventory.Application.Subscribers;
public class OnOrderCreated : IEventHandler<OrderCreatedEvent>
{
    private readonly ReserveProductUseCase _reserveListProductsUseCase;
    public OnOrderCreated(
        ReserveProductUseCase reserveListProductsUseCase)
    {
        _reserveListProductsUseCase = reserveListProductsUseCase;
        EventHandler.Register(
            typeof(OrderCreatedEvent).Name,
            (IEventHandler<IDomainEvent>)this);
    }

    public Task HandleAsync(OrderCreatedEvent domainEvent)
    {
        throw new NotImplementedException();
    }
}
