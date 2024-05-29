using Marombastore.Core.Seedwork;
using Marombastore.Notification.Application.Dto;
using Marombastore.Notification.Domain.Repository;

namespace Marombastore.Notification.Application.UseCases;

public class ReadNotificationUseCase : IUseCase<ReadNotificationInputDto>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;
    public ReadNotificationUseCase(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
    {
        _notificationRepository = notificationRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task Execute(ReadNotificationInputDto data)
    {
        var notification = await _notificationRepository.GetById(data.NotificationId);

        if (notification == null || notification.DeletedAt != null)
            throw new Exception("Notification not found");

        if (notification.RecipientId != data.RecipientId)
            throw new Exception("unauthorized access");

        notification.MarkAsRead();

        await _notificationRepository.UpdateAsync(notification);
        await _unitOfWork.Commit();
    }
}