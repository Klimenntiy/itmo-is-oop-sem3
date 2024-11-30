namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Loggers;

public class ConsoleLogger : ILogger
{
    public void LogMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentException("Message cannot be null or empty.", nameof(message));
        }

        Console.WriteLine($"Message logged: {message}");
    }
}