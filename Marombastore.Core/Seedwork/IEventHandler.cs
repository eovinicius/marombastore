namespace Marombastore.Core.Seedwork;

public interface IEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
{
    Task HandleAsync(TDomainEvent domainEvent);
}