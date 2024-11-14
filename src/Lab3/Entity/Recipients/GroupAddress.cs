using Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Recipients;

public class GroupAddress : IAddress
{
    private readonly List<IAddress> _addresses = [];

    public void AddAddress(IAddress address)
    {
        if (address == null)
        {
            throw new ArgumentNullException(nameof(address), "Address cant be null.");
        }

        _addresses.Add(address);
    }

    public FinalResult AcceptMessage(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cant be null.");
        }

        foreach (IAddress address in _addresses)
        {
            address.AcceptMessage(message);
        }

        return new FinalResult.Success();
    }
}