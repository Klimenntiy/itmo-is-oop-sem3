using Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Proxys;

public class Proxy : IAddress
{
    private readonly IAddress _address;
    private readonly int _requiredImportance;

    public Proxy(IAddress address, int importance)
    {
        _address = address ?? throw new ArgumentNullException(nameof(address), "Address cant be null.");
        _requiredImportance = importance;
    }

    public FinalResult AcceptMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));

        if (message.Priority == _requiredImportance)
        {
            return _address.AcceptMessage(message);
        }

        return new FinalResult.Unimportant();
    }
}