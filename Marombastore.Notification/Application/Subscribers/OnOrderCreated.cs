using Marombastore.Core.Seedwork;
using Marombastore.Notification.Application.Dto;
using Marombastore.Notification.Application.UseCases;
using Marombastore.Order.Domain.Events;
using EventHandler = Marombastore.Core.Seedwork.EventHandler;

namespace Marombastore.Notification.Application.Subscribers;

public class OnOrderCreated : IEventHandler<OrderCreatedEvent>
{
    private readonly SendNotificationUseCase _sendNotificationUseCase;
    public OnOrderCreated(SendNotificationUseCase sendNotificationUseCase)
    {
        _sendNotificationUseCase = sendNotificationUseCase;
        EventHandler.Register(typeof(OrderCreatedEvent).Name, (IEventHandler<IDomainEvent>)this);
    }

    public Task HandleAsync(OrderCreatedEvent domainEvent)
    {
        var notification = new SendNotificationInputDto
        (
            domainEvent.GetAggregateRootId(),
            "Order created",
            "Your order has been created"
        );

        return _sendNotificationUseCase.Execute(notification);
    }
}