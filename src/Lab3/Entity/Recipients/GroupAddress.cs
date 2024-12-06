using Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Recipients;

public class GroupAddress
{
    private readonly List<IAddress> _addresses = new List<IAddress>();

    public IEnumerable<IAddress> UserMessages => _addresses;

    public void AddAddress(IAddress address)
    {
        if (address == null)
        {
            throw new ArgumentNullException(nameof(address), "Address can't be null.");
        }

        _addresses.Add(address);
    }

    public void AcceptGroupMessage(IMessage message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message can't be null.");
        }

        foreach (IAddress address in _addresses)
        {
            address.AcceptMessage(message);
        }
    }
}