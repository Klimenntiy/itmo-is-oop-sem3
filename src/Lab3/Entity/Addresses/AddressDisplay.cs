using Itmo.ObjectOrientedProgramming.Lab3.Entity.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;

public class AddressDisplay : IAddress
{
    private readonly Display _display;

    public AddressDisplay(Display display)
    {
        _display = display;
    }

    public FinalResult AcceptMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        _display.AcceptMessage(message);
        return new FinalResult.Success();
    }
}