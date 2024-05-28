namespace Marombastore.Inventory.Application.Dto;
public record UnreservebleProductOutputDto(
    Guid ProductId,
    int MaxPossibleQuantity
);
