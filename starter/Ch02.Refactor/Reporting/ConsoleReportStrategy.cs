
using EduHub.Ch02.Abstractions;
using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Reporting;

public class ConsoleReportStrategy : IReportStrategy
{
    public string Generate(IReadOnlyList<ClubReportRow> rows)
    {
        return string.Join(
            Environment.NewLine,
            rows.Select(row =>
                $"Club: {row.ClubName} | Members: {row.MemberCount}"));
    }
}
