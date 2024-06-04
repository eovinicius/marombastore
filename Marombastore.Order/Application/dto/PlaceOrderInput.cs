namespace Marombastore.Order.Application.dto;

public record PlaceOrderInput(Guid Id, Guid CustomerId, OrderItem[] OrderItems) { }
public record OrderItem(Guid ItemId, int Quantity) { }