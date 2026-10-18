
using EduHub.Ch02.Abstractions;
using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Services;

public class ReportService
{
    private readonly IClubRepository _repository;

    public ReportService(IClubRepository repository)
    {
        _repository = repository;
    }

    public string Generate(IReportStrategy strategy)
    {
        var rows = _repository.GetAllClubs()
            .Select(club => new ClubReportRow
            {
                ClubName = club.Name,
                MemberCount =
                    _repository.GetMembersByClubId(club.Id).Count
            })
            .ToList();

        return strategy.Generate(rows);
    }
}
