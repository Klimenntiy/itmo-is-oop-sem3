using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Recipients;

public class UserMessage
{
    public UserMessage(IMessage message, bool isRead)
    {
        Message = message;
        IsRead = isRead;
    }

    public IMessage Message { get; }

    public bool IsRead { get; private set; }

    public ModifyResult MessageRead()
    {
        if (IsRead)
        {
            return new ModifyResult(new FinalResult.TheMessageHasAlreadyBeenRead(), true);
        }

        IsRead = true;
        return new ModifyResult(new FinalResult.Success(), IsRead);
    }
}