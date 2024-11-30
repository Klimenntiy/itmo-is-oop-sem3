namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Loggers;

public class MessageLogger : ILogger
{
    private readonly List<string> _log = new List<string>();

    public IEnumerable<string> UserMessages => _log;

    public MessageLogger()
    {
        _log = new List<string>();
    }

    public void LogMessage(string message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        _log.Add(message);
    }
}