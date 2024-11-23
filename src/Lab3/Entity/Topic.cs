using Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public class Topic
{
    public Topic(string name, IAddress address)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name), "Name can't be null.");
        Address = address ?? throw new ArgumentNullException(nameof(address), "Address can't be null.");
    }

    public string Name { get; protected set; }

    private IAddress Address { get; }

    public FinalResult SendMessage(Message message)
    {
        return Address.AcceptMessage(message);
    }
}