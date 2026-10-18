using EduHub.Ch02.Abstractions;
using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Notifications;

public class NotificationServiceFactory
    : INotificationServiceFactory
{
    private readonly Dictionary<
        NotificationChannel,
        INotificationService> _services;

    public NotificationServiceFactory(
        Dictionary<NotificationChannel, INotificationService> services)
    {
        _services = services;
    }

    public INotificationService Create(NotificationChannel channel)
    {
        if (_services.TryGetValue(channel, out var service))
        {
            return service;
        }

        throw new NotSupportedException(
            $"Unsupported notification channel: {channel}");
    }
}