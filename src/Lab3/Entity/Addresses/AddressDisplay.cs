using Itmo.ObjectOrientedProgramming.Lab3.Entity.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;

public class AddressDisplay : IAddress
{
    private readonly Display _display;

    public AddressDisplay(Display display)
    {
        _display = display;
    }

    public FinalResult AcceptMessage(IMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);

        string messageText = message.Body;

        _display.AcceptMessage(messageText);
        return new FinalResult.Success();
    }
}