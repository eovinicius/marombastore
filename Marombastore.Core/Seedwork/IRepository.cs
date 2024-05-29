namespace Marombastore.Core.Seedwork;

public interface IRepository<Tagregate> where Tagregate : AggregateRoot
{
    Task CreateAsync(Tagregate aggregate);
    Task UpdateAsync(Tagregate aggregate);
    Task<Tagregate> GetById(Guid id);
}