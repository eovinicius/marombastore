namespace Marombastore.Core.Seedwork;

public interface IRepository<Aggregate>
{
    Task Create(Aggregate aggregate);
    // TODO: name this method better, like UpdateAsync
    Task Update(Aggregate aggregate);
    Task<Aggregate> GetById(Guid id);
}
