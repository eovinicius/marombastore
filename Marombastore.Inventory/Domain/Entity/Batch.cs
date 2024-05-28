using Marombastore.Core.Seedwork;
using Marombastore.Inventory.Domain.Enum;

namespace Marombastore.Inventory.Domain.Entity;
public class Batch : EntityBase
{
    public Guid ProductId { get; private set; }
    public Guid InternalCode { get; private set; }
    public int Quantity { get; private set; }
    public EStatusBatch Status { get; private set; }
    public DateTime FabricationAt { get; private set; }
    public DateTime ExpirateAt { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Batch(
        Guid productId,
        Guid internalCode,
        int quantity,
        DateTime fabricationAt,
        DateTime expirateAt)
    {
        ProductId = productId;
        InternalCode = internalCode;
        Quantity = quantity;
        FabricationAt = fabricationAt;
        ExpirateAt = expirateAt;
        CreatedAt = DateTime.Now;

        UpdateStatus();
    }

    public void UpdateQuantity(int quantity)
    {
        Quantity = quantity;

        if (Quantity <= 0)
            Status = EStatusBatch.Unavailable;
    }

    public void UpdateStatus()
    {
        Status = EStatusBatch.Available;

        if (Quantity <= 0)
            Status = EStatusBatch.Unavailable;

        if (DateTime.Now > ExpirateAt)
            Status = EStatusBatch.Expired;
    }
}
