using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Loggers;

public class ConsoleLogger : ILogger
{
    public void LogMessage(IMessage message)
    {
        Console.WriteLine($"Message logged: {message.Body}");
    }
}
