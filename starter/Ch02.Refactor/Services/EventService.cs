
using EduHub.Ch02.Abstractions;
using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Services;

public class EventService
{
    private readonly IClubRepository _repository;
    private readonly IEnumerable<IEventObserver> _observers;

    public EventService(
        IClubRepository repository,
        IEnumerable<IEventObserver> observers)
    {
        _repository = repository;
        _observers = observers;
    }

    public Event CreateEvent(
        Guid clubId,
        string title,
        DateTime date)
    {
        var club = _repository.GetClubById(clubId)
            ?? throw new InvalidOperationException("Club not found");

        var ev = new Event
        {
            Id = Guid.NewGuid(),
            ClubId = clubId,
            Title = title,
            Date = date
        };

        _repository.AddEvent(ev);

        foreach (var observer in _observers)
        {
            observer.OnEventCreated(ev, club);
        }

        return ev;
    }
}
