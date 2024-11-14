using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Recipients;

public class UserMessage
{
    public UserMessage(Message message, bool isRead)
    {
        Message = message ?? throw new ArgumentNullException(nameof(message), "Message cant be null.");
    }

    public Message Message { get; }

    public bool IsRead { get; private set; }

    public (FinalResult Res, bool Bool) MessageRead()
    {
        if (IsRead)
        {
            return (new FinalResult.TheMessageHasAlreadyBeenRead(), true);
        }

        IsRead = true;
        return (new FinalResult.Success(), IsRead);
    }
}