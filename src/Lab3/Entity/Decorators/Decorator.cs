using Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Decorators;

public class Decorator : IAddress
{
    private readonly IAddress _address;

    public Decorator(IAddress address)
    {
        _address = address ?? throw new ArgumentNullException(nameof(address));
        Log = [];
    }

    public virtual ICollection<Message> Log { get; }

    public FinalResult AcceptMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        Log.Add(message);

        _address.AcceptMessage(message);
        return new FinalResult.Success();
    }
}