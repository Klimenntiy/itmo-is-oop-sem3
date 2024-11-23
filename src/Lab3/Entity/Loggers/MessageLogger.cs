using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Loggers;

public class MessageLogger : ILogger
{
    private readonly List<IMessage> log;

    public MessageLogger()
    {
        log = new List<IMessage>();
    }

    public void LogMessage(IMessage message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        log.Add(message);
    }

    public ReadOnlyCollection<IMessage> GetLogs()
    {
        return log.AsReadOnly();
    }
}