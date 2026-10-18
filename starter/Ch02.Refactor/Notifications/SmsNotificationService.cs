using EduHub.Ch02.Abstractions;

namespace EduHub.Ch02.Notifications;

public class SmsNotificationService : INotificationService
{
    public void Send(string recipient, string message)
    {
        Console.WriteLine($"[SMS] to {recipient}: {message}");
    }
}