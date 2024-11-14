using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;

public class AddressUser : IAddress
{
    private readonly User _user;

    public AddressUser(User user)
    {
        _user = user ?? throw new ArgumentNullException(nameof(user));
    }

    public FinalResult AcceptMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        _user.AcceptMessage(message);
        return new FinalResult.Success();
    }
}