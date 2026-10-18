using EduHub.Ch02.Abstractions;
using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Notifications;

public class LogNotifier : IEventObserver
{
    private readonly IAppLogger _logger;

    public LogNotifier(IAppLogger logger)
    {
        _logger = logger;
    }

    public void OnEventCreated(Event ev, Club club)
    {
        _logger.Info(
            $"Event created: {ev.Title} for club {club.Name}");
    }
}