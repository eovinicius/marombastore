namespace Marombastore.Core.Seedwork;

public class AggregateRoot : EntityBase
{
    private readonly List<IDomainEvent> _domainEvents = [];
    public AggregateRoot() : base() { }

    //event methods
    protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    public IReadOnlyList<IDomainEvent> Events => _domainEvents;
    public void ClearEvents() => _domainEvents.Clear();
}