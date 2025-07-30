using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;

public class AddressMessenger : IAddress
{
    private readonly Messenger _messenger;

    public AddressMessenger(Messenger messenger)
    {
        _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger), "Messenger can't be null.");
    }

    public FinalResult AcceptMessage(IMessage message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));

        IMessage clonedMessage = message.Clone();
        _messenger.Print(clonedMessage.Body);
        return new FinalResult.Success();
    }
}