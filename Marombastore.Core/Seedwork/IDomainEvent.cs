namespace Marombastore.Core.Seedwork
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
        Guid GetAggregateRootId();
    }
}