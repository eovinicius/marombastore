using Marombastore.Core.Seedwork;
using Marombastore.Inventory.Domain.Enum;

namespace Marombastore.Inventory.Domain.Entity;
public class InventoryBatch : EntityBase
{
    public Guid ProductId { get; private set; }
    public Guid InternalCode { get; private set; }
    public int Quantity { get; private set; }
    public EStatusInventoryBatch Status { get; private set; }
    public DateTime FabricationAt { get; private set; }
    public DateTime ExpirateAt { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public InventoryBatch(
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
            Status = EStatusInventoryBatch.Unavailable;
    }

    public void UpdateStatus()
    {
        Status = EStatusInventoryBatch.Available;

        if (Quantity <= 0)
            Status = EStatusInventoryBatch.Unavailable;

        if (DateTime.Now > ExpirateAt)
            Status = EStatusInventoryBatch.Expired;
    }
}
