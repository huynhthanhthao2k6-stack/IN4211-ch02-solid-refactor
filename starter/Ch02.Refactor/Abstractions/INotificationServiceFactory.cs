using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Abstractions;

public interface INotificationServiceFactory
{
    INotificationService Create(NotificationChannel channel);
}