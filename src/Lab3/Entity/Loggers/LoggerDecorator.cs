using Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Loggers;

public class LoggerDecorator : IAddress
{
    private readonly IAddress _address;
    private readonly ILogger _logger;

    public LoggerDecorator(IAddress address, ILogger logger)
    {
        _address = address ?? throw new ArgumentNullException(nameof(address), "Address can't be null.");
        _logger = logger ?? throw new ArgumentNullException(nameof(logger), "Logger can't be null.");
    }

    public FinalResult AcceptMessage(IMessage message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));

        _logger.LogMessage(message);

        return _address.AcceptMessage(message);
    }

    public ReadOnlyCollection<IMessage> GetLogs()
    {
        return (_logger as MessageLogger)?.GetLogs() ?? new ReadOnlyCollection<IMessage>(new List<IMessage>());
    }
}