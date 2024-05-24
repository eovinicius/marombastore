namespace Marombastore.Core.Seedwork;

public interface IRepository<Aggregate>
{
    Task Create(Aggregate aggregate);
    Task Update(Aggregate aggregate);
    Task<Aggregate> GetById(Guid id);
}