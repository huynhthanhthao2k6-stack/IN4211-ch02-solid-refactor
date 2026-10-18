using EduHub.Ch02.Abstractions;
using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Notifications;

public class EmailNotifier : IEventObserver
{
    private readonly IClubRepository _repository;
    private readonly INotificationServiceFactory _factory;

    public EmailNotifier(
        IClubRepository repository,
        INotificationServiceFactory factory)
    {
        _repository = repository;
        _factory = factory;
    }

    public void OnEventCreated(Event ev, Club club)
    {
        var members = _repository.GetMembersByClubId(club.Id);
        var emailService = _factory.Create(NotificationChannel.Email);

        foreach (var member in members)
        {
            emailService.Send(
                member.Email,
                $"New event: {ev.Title} at {club.Name}");
        }
    }
}