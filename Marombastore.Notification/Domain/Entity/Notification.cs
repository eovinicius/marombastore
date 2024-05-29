using Marombastore.Core.Seedwork;

namespace Marombastore.Notification.Domain.Entity;

public class Notification : AggregateRoot
{
    public Guid RecipientId { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public DateTime? ReadAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    public Notification(Guid recipientId, string title, string content)
    {
        RecipientId = recipientId;
        Title = title;
        Content = content;
    }

    public Guid GetId()
    {
        return Id;
    }

    public void MarkAsRead()
    {
        ReadAt = DateTime.Now;
    }
    public void MarkAsDeleted()
    {
        DeletedAt = DateTime.Now;
    }
}