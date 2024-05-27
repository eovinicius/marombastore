using Marombastore.Core.Seedwork;
using Marombastore.Inventory.Domain.Entity;

namespace Marombastore.Inventory.Domain.Repository;
public interface IProductRepository : IRepository<Product>
{
    Task UpdateProduct(Product product);
}
