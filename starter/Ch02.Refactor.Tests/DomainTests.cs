
using EduHub.Ch02;
using EduHub.Ch02.Domain;
using Xunit;

namespace Ch02.Refactor.Tests;

// AAA: Arrange - Act - Assert.
public class DomainTests
{
    [Fact]
    public void CreateClub_WithEmptyName_ThrowsArgumentException()
    {
        // Arrange
        var manager = new ClubManager();

        // Act
        var act = () => manager.CreateClub("", "mô tả", "p@gmail.com");

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Fact]
    public void Club_Create_WithValidName_ReturnsClub()
    {
        // Arrange
        var name = "IT Club";
        var description = "Câu lạc bộ công nghệ";

        // Act
        var club = Club.Create(name, description);

        // Assert
        Assert.NotEqual(Guid.Empty, club.Id);
        Assert.Equal(name, club.Name);
        Assert.Equal(description, club.Description);
    }

    public static IEnumerable<object[]> InvalidClubNames =>
        new[]
        {
            new object[] { "" },
            new object[] { "   " },
            new object[] { new string('A', 101) }
        };

    [Theory]
    [MemberData(nameof(InvalidClubNames))]
    public void Club_Create_WithInvalidName_ThrowsArgumentException(
        string name)
    {
        // Arrange
        var description = "Câu lạc bộ công nghệ";

        // Act
        var act = () => Club.Create(name, description);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }

    [Theory]
    [InlineData(49, true)]
    [InlineData(50, false)]
    public void Club_HasRoom_AtMemberLimit_ReturnsExpectedResult(
        int currentMemberCount,
        bool expected)
    {
        // Arrange
        var club = Club.Create("IT Club", "Câu lạc bộ công nghệ");

        // Act
        var result = club.HasRoom(currentMemberCount);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Event_Register_NewMember_ReturnsTrue()
    {
        // Arrange
        var ev = new Event
        {
            Id = Guid.NewGuid(),
            ClubId = Guid.NewGuid(),
            Title = "Workshop C#",
            Date = DateTime.Today
        };

        var memberId = Guid.NewGuid();

        // Act
        var result = ev.Register(memberId);

        // Assert
        Assert.True(result);
        Assert.Contains(memberId, ev.RegisteredMemberIds);
    }

    [Fact]
    public void Event_Register_SameMemberTwice_ReturnsFalse()
    {
        // Arrange
        var ev = new Event
        {
            Id = Guid.NewGuid(),
            ClubId = Guid.NewGuid(),
            Title = "Workshop C#",
            Date = DateTime.Today
        };

        var memberId = Guid.NewGuid();
        ev.Register(memberId);

        // Act
        var result = ev.Register(memberId);

        // Assert
        Assert.False(result);
        Assert.Single(ev.RegisteredMemberIds);
    }

    [Fact]
    public void Event_CheckIn_UnregisteredMember_ThrowsInvalidOperationException()
    {
        // Arrange
        var ev = new Event
        {
            Id = Guid.NewGuid(),
            ClubId = Guid.NewGuid(),
            Title = "Workshop C#",
            Date = DateTime.Today
        };

        var memberId = Guid.NewGuid();

        // Act
        var act = () => ev.CheckIn(memberId);

        // Assert
        Assert.Throws<InvalidOperationException>(act);
    }

    [Fact]
    public void Event_CheckIn_RegisteredMember_AddsMemberToCheckedInList()
    {
        // Arrange
        var ev = new Event
        {
            Id = Guid.NewGuid(),
            ClubId = Guid.NewGuid(),
            Title = "Workshop C#",
            Date = DateTime.Today
        };

        var memberId = Guid.NewGuid();
        ev.Register(memberId);

        // Act
        ev.CheckIn(memberId);

        // Assert
        Assert.Contains(memberId, ev.CheckedInMemberIds);
    }
}
