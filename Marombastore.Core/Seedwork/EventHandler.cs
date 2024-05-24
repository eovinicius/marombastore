

namespace Marombastore.Core.Seedwork;

public class EventHandler
{
    private static readonly Dictionary<string, List<IEventHandler<IDomainEvent>>> _handlers = [];

    public static void Register(string eventName, IEventHandler<IDomainEvent> handler)
    {
        if (!_handlers.ContainsKey(eventName))
        {
            _handlers.Add(eventName, []);
        }

        _handlers[eventName].Add(handler);

    }

    public static void Dispatch(IDomainEvent domainEvent)
    {
        if (!_handlers.ContainsKey(domainEvent.GetType().Name))
        {
            return;
        }

        foreach (var handler in _handlers[domainEvent.GetType().Name])
        {
            handler.HandleAsync(domainEvent);
        }
    }

    public static void Remove(IDomainEvent domainEvent)
    {
        if (!_handlers.ContainsKey(domainEvent.GetType().Name))
        {
            return;
        }

        foreach (var handler in _handlers[domainEvent.GetType().Name])
        {
            _handlers[domainEvent.GetType().Name].Remove(handler);
        }
    }

}