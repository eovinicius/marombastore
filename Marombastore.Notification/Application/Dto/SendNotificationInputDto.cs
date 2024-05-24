namespace Marombastore.Notification.Application.Dto;

public record SendNotificationInputDto(Guid RecipientId, string Title, string Content);