using Marombastore.Core.Seedwork;
using Marombastore.Notification.Application.Dto;
using Entity = Marombastore.Notification.Domain.Entity;
using Marombastore.Notification.Domain.Repository;

namespace Marombastore.Notification.Application.UseCases;

public class SendNotificationUseCase
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SendNotificationUseCase(
        INotificationRepository notificationRepository,
        IUnitOfWork unitOfWork
    )
    {
        _notificationRepository = notificationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(SendNotificationInputDto data)
    {
        var alreadyExist = _notificationRepository.GetById(data.RecipientId);

        if (alreadyExist != null)
        {
            throw new Exception("Notification already exists");
        }

        var notification = new Entity.Notification(data.RecipientId, data.Title, data.Content);

        await _notificationRepository.CreateAsync(notification);

        await _unitOfWork.Commit();
    }
}