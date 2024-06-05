namespace Marombastore.Order.Application.dto;

public record PlaceOrderInput(Guid CustomerId, OrderItem[] OrderItems, Guid? CouponId) { }
public record OrderItem(Guid ItemId, int Quantity) { }