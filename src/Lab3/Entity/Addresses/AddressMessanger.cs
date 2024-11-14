using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;

public class AddressMessanger : IAddress
{
    private readonly Messenger _messenger;

    public AddressMessanger(Messenger messanger)
    {
        _messenger = messanger;
    }

    public FinalResult AcceptMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        _messenger.AcceptMessage(message);
        return new FinalResult.Success();
    }
}