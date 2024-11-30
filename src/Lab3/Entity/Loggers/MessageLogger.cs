using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Loggers;

public class MessageLogger : ILogger
{
    private readonly List<string> log;

    public MessageLogger()
    {
        log = new List<string>();
    }

    public void LogMessage(string message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        log.Add(message);
    }

    public ReadOnlyCollection<string> GetLogs()
    {
        return log.AsReadOnly();
    }
}