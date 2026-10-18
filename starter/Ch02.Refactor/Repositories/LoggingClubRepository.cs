
using EduHub.Ch02.Abstractions;
using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Repositories;

/// <summary>
/// Decorator bổ sung chức năng ghi log cho repository.
/// </summary>
public class LoggingClubRepository : IClubRepository
{
    private readonly IClubRepository _inner;
    private readonly IAppLogger _logger;

    public LoggingClubRepository(
        IClubRepository inner,
        IAppLogger logger)
    {
        _inner = inner;
        _logger = logger;
    }

    public void AddClub(Club club)
    {
        _logger.Info($"Adding club: {club.Name}");
        _inner.AddClub(club);
    }

    public Club? GetClubById(Guid id)
    {
        _logger.Info($"Getting club: {id}");
        return _inner.GetClubById(id);
    }

    public IReadOnlyList<Club> GetAllClubs()
    {
        _logger.Info("Getting all clubs");
        return _inner.GetAllClubs();
    }

    public void AddMember(Member member)
    {
        _logger.Info($"Adding member: {member.Name}");
        _inner.AddMember(member);
    }

    public IReadOnlyList<Member> GetMembersByClubId(Guid clubId)
    {
        _logger.Info($"Getting members for club: {clubId}");
        return _inner.GetMembersByClubId(clubId);
    }

    public void AddEvent(Event ev)
    {
        _logger.Info($"Adding event: {ev.Title}");
        _inner.AddEvent(ev);
    }

    public IReadOnlyList<Event> GetEventsByClubId(Guid clubId)
    {
        _logger.Info($"Getting events for club: {clubId}");
        return _inner.GetEventsByClubId(clubId);
    }
}
