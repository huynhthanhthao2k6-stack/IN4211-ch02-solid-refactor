
using EduHub.Ch02.Abstractions;
using EduHub.Ch02.Domain;
using EduHub.Ch02.Logging;
using EduHub.Ch02.Notifications;
using EduHub.Ch02.Reporting;
using EduHub.Ch02.Repositories;
using EduHub.Ch02.Services;

// 1. Khởi tạo logger và repository.
// Decorator bọc InMemoryClubRepository để ghi log.
IAppLogger logger = new ConsoleAppLogger();

IClubRepository repository = new LoggingClubRepository(
    new InMemoryClubRepository(),
    logger);

// 2. Factory tạo dịch vụ thông báo theo kênh.
var notificationServices =
    new Dictionary<NotificationChannel, INotificationService>
    {
        [NotificationChannel.Email] = new EmailNotificationService(),
        [NotificationChannel.Sms] = new SmsNotificationService(),
        [NotificationChannel.Slack] = new SlackNotificationService()
    };

INotificationServiceFactory factory =
    new NotificationServiceFactory(notificationServices);

// 3. ClubService tạo CLB và thêm thành viên.
var clubService = new ClubService(repository, factory);

var club = clubService.CreateClub(
    "Tech Club",
    "Câu lạc bộ công nghệ",
    "president@gmail.com",
    NotificationChannel.Email);

var member = clubService.AddMemberToClub(
    club.Id,
    "Nguyễn Văn A",
    "a@student.dthu.edu.vn");

// 4. Observer nhận thông báo khi tạo sự kiện.
IEventObserver[] observers =
{
    new EmailNotifier(repository, factory),
    new LogNotifier(logger)
};

var eventService = new EventService(repository, observers);

var ev = eventService.CreateEvent(
    club.Id,
    "Workshop SOLID",
    new DateTime(2026, 11, 20));

Console.WriteLine($"\nCreated event: {ev.Title}");

// 5. Strategy xuất báo cáo Console và CSV.
var reportService = new ReportService(repository);

Console.WriteLine("\n=== CONSOLE REPORT ===");
Console.WriteLine(reportService.Generate(new ConsoleReportStrategy()));

Console.WriteLine("\n=== CSV REPORT ===");
Console.WriteLine(reportService.Generate(new CsvReportStrategy()));

Console.WriteLine("\nDemo completed.");
