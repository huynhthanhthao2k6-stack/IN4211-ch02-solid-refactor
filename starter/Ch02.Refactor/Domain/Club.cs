
namespace EduHub.Ch02.Domain;

/// <summary>
/// Câu lạc bộ. Quy tắc nghiệp vụ nằm trong Domain.
/// </summary>
public class Club
{
    public const int MaxMembers = 50;
    public const int MaxNameLength = 100;

    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    /// <summary>
    /// Tạo câu lạc bộ sau khi kiểm tra tên hợp lệ.
    /// </summary>
    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Club name is required",
                nameof(name));
        }

        if (name.Length > MaxNameLength)
        {
            throw new ArgumentException(
                "Club name too long",
                nameof(name));
        }

        return new Club
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description
        };
    }

    /// <summary>
    /// Kiểm tra câu lạc bộ còn chỗ cho thành viên mới hay không.
    /// </summary>
    public bool HasRoom(int currentMemberCount)
    {
        return currentMemberCount < MaxMembers;
    }
}
