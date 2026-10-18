
using EduHub.Ch02.Abstractions;
using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Reporting;

public class CsvReportStrategy : IReportStrategy
{
    public string Generate(IReadOnlyList<ClubReportRow> rows)
    {
        var lines = new List<string>
        {
            "ClubName,MemberCount"
        };

        foreach (var row in rows)
        {
            var name = row.ClubName.Replace("\"", "\"\"");
            lines.Add($"\"{name}\",{row.MemberCount}");
        }

        return string.Join(Environment.NewLine, lines);
    }
}
