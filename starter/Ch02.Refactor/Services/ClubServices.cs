
using EduHub.Ch02.Abstractions;
using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Services;

public class ClubService
{
    private readonly IClubRepository _repository;
    private readonly INotificationServiceFactory _notificationFactory;

    public ClubService(
        IClubRepository repository,
        INotificationServiceFactory notificationFactory)
    {
        _repository = repository;
        _notificationFactory = notificationFactory;
    }

    public Club CreateClub(
        string name,
        string description,
        string presidentEmail,
        NotificationChannel channel)
    {
        var club = Club.Create(name, description);

        _repository.AddClub(club);

        var notifier = _notificationFactory.Create(channel);
        notifier.Send(
            presidentEmail,
            $"Club created: {club.Name}");

        return club;
    }

    public Member AddMemberToClub(
        Guid clubId,
        string memberName,
        string email)
    {
        var club = _repository.GetClubById(clubId)
            ?? throw new InvalidOperationException("Club not found");

        var members = _repository.GetMembersByClubId(clubId);

        if (!club.HasRoom(members.Count))
        {
            throw new InvalidOperationException(
                "Club is full (max 50 members)");
        }

        var member = new Member
        {
            Id = Guid.NewGuid(),
            Name = memberName,
            Email = email,
            ClubId = clubId
        };

        _repository.AddMember(member);

        return member;
    }
}
