using Marombastore.Core.Seedwork;
using Marombastore.Inventory.Domain.DataTransferObject;
using Marombastore.Inventory.Domain.Enum;

namespace Marombastore.Inventory.Domain.Entity;
public class Product : AggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int TotalSold { get; private set; }
    public int TotalQuatity { get; private set; }
    public int ReservedQuatity { get; private set; }
    public List<Batch> DispobibleBatches { get; set; }
    public List<Batch> Batches { get; set; }
    public int AvailableQuantity => TotalQuatity - ReservedQuatity;
    public bool Active { get; private set; } = true;

    public Product(
        string name,
        string description,
        decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
        TotalQuatity = 0;
        Batches = new List<Batch>();
        DispobibleBatches = new List<Batch>();
    }

    // NOTE: não parece certo, mudar depois
    public void AddBatch(Batch batch)
    {
        if (batch.ProductId != Id)
            throw new Exception("Batch is not from this product");

        Batches.Add(batch);
        DispobibleBatches.Add(batch);
        TotalQuatity += batch.Quantity;
    }

    public void RemoveFromBatch(RemoveBatchDto batch)
    {
        throw new NotImplementedException();
    }

    public void RemoveFromBatchs(List<RemoveBatchDto> batches)
    {
        throw new NotImplementedException();
    }

    public void ReserveQuantity(int quantity)
    {
        if (quantity > AvailableQuantity)
            throw new Exception("Quantity not available");

        ReservedQuatity += quantity;
    }

    public void FetchBatchById(Guid batchId)
    {
        throw new NotImplementedException();
    }

    public void FetchBatchByInternalCode(Guid internalCode)
    {
        throw new NotImplementedException();
    }

    public void FetchBatchsByStatus(EStatusBatch status)
    {
        throw new NotImplementedException();
    }
}
