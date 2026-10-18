namespace EduHub.Ch02.Abstractions;

public interface INotificationService
{
    void Send(string recipient, string message);
}