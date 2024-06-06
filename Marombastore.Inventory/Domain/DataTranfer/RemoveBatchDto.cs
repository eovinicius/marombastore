namespace Marombastore.Inventory.Domain.DataTransferObject;
public class RemoveBatchDto
{
    public Guid BatchId { get; set; }
    public int Quantity { get; set; }
}
