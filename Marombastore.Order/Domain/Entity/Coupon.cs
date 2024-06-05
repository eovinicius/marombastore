using Marombastore.Core.Seedwork;

namespace Marombastore.Order.Domain.Entity;

public class Coupon : AggregateRoot
{
    public string Code { get; private set; }
    public decimal Discount { get; private set; }
    public DateTime ExpirationDate { get; private set; }

    public Coupon(string code, decimal discount, DateTime expirationDate)
    {
        Code = code;
        Discount = discount;
        ExpirationDate = expirationDate;
    }

    public bool IsValid()
    {
        return DateTime.Now <= ExpirationDate;
    }
}