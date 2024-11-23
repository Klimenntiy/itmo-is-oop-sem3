using Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Filters;

public class ImportanceFilter : IMessageFilter
{
    public FinalResult Filter(IMessage message, IAddress address, int importance)
    {
        if (message.Priority == importance)
        {
            return address.AcceptMessage(message);
        }

        return new FinalResult.Unimportant();
    }
}