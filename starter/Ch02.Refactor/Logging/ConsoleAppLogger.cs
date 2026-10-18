
using EduHub.Ch02.Abstractions;

namespace EduHub.Ch02.Logging;

public class ConsoleAppLogger : IAppLogger
{
    public void Info(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
}
