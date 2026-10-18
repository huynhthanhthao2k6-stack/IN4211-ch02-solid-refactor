
using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Abstractions;

public interface IClubRepository
{
    void AddClub(Club club);

    Club? GetClubById(Guid id);

    IReadOnlyList<Club> GetAllClubs();

    void AddMember(Member member);

    IReadOnlyList<Member> GetMembersByClubId(Guid clubId);

    void AddEvent(Event ev);

    IReadOnlyList<Event> GetEventsByClubId(Guid clubId);
}
