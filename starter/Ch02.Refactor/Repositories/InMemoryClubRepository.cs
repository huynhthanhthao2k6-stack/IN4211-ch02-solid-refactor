
using EduHub.Ch02.Abstractions;
using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Repositories;

public class InMemoryClubRepository : IClubRepository
{
    private readonly List<Club> _clubs = new();
    private readonly List<Member> _members = new();
    private readonly List<Event> _events = new();

    public void AddClub(Club club)
    {
        _clubs.Add(club);
    }

    public Club? GetClubById(Guid id)
    {
        return _clubs.FirstOrDefault(c => c.Id == id);
    }

    public IReadOnlyList<Club> GetAllClubs()
    {
        return _clubs.ToList();
    }

    public void AddMember(Member member)
    {
        _members.Add(member);
    }

    public IReadOnlyList<Member> GetMembersByClubId(Guid clubId)
    {
        return _members
            .Where(m => m.ClubId == clubId)
            .ToList();
    }

    public void AddEvent(Event ev)
    {
        _events.Add(ev);
    }

    public IReadOnlyList<Event> GetEventsByClubId(Guid clubId)
    {
        return _events
            .Where(e => e.ClubId == clubId)
            .ToList();
    }
}
