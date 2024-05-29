using Marombastore.Core.Seedwork;
using Marombastore.Payment.Domain.Enum;

namespace Marombastore.Payment.Domain.Entity;

public class Payment : AggregateRoot
{
    public int PayerId { get; set; }
    public int OrderId { get; set; }
    public EPaymentMethod PaymentMethod { get; set; }
    public float Price { get; set; }
    public EStatus Status { get; set; }
    public DateTime ConfirmedAt { get; set; }
}
