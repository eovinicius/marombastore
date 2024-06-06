using Marombastore.Core.Seedwork;
using Marombastore.Inventory.Domain.Entity;
using Marombastore.Inventory.Domain.Enum;

namespace Marombastore.Inventory.Domain.Repository;
public interface IProductRepository : IRepository<Product>
{
    Task UpdateBatchs(IEnumerable<Batch> batchs);
    Task UpdateBatch(Batch batch);
    Task GetDispobibleBatchs(Guid productId);
    Task GetBatchByInternalCode(Guid internalCode);
    Task GetBatchsById(Guid productId);
    Task GetBatchsByStatus(EStatusBatch status);
}
