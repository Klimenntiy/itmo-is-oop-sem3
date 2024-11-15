using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;

public class AddressMessenger : IAddress
{
    private readonly Messenger _messenger;

    public AddressMessenger(Messenger messenger)
    {
        _messenger = messenger;
    }

    public FinalResult AcceptMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        Message clonedMessage = message.Clone();
        _messenger.AcceptMessage(clonedMessage);
        return new FinalResult.Success();
    }
}