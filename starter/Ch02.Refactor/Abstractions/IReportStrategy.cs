
using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Abstractions;

public interface IReportStrategy
{
    string Generate(IReadOnlyList<ClubReportRow> rows);
}
