using Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Decorators;

public class Decorator : IAddress
{
    private readonly IAddress _address;
    private readonly List<Message> _log;

    public Decorator(IAddress address)
    {
        _address = address ?? throw new ArgumentNullException(nameof(address), "Address can't be null.");
        _log = [];
    }

    public IReadOnlyCollection<Message> Log => _log.AsReadOnly();

    public virtual FinalResult AcceptMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));

        _log.Add(message);

        _address.AcceptMessage(message);
        return new FinalResult.Success();
    }
}