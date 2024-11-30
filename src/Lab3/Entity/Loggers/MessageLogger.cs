namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Loggers;

public class MessageLogger : ILogger
{
    private readonly IEnumerable<string> _log;

    public MessageLogger()
    {
        _log = new List<string>();
    }

    public void LogMessage(string message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        _log.Append(message);
    }
}