namespace Marombastore.Order.Application.dto;

public record PlaceOrderInput(Guid Id, Guid CustomerId, ItemInput[] Items) { }
public record ItemInput(Guid ItemId, int Quantity) { }