using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Recipients;

public class User
{
    public User(string name, string title)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name), "Name cant be null.");
        Title = title ?? throw new ArgumentNullException(nameof(title), "Title cant be null.");
    }

    public User(User user)
    {
        Name = user.Name;
        Title = user.Title;
        UserMessages = new List<UserMessage?>(user.UserMessages);
    }

    public ICollection<UserMessage?> UserMessages { get; } = [];

    private string Name { get; }

    private string Title { get; }

    public static bool CheckStatus(UserMessage? message)
    {
        ArgumentNullException.ThrowIfNull(message);
        return message.IsRead;
    }

    public void AcceptMessage(Message message)
    {
        var userMessage = new UserMessage(message, false);
        UserMessages.Add(userMessage);
    }

    public FinalResult MessageIsRead(int index)
    {
        UserMessage? message = UserMessages.ElementAtOrDefault(index);
        ArgumentNullException.ThrowIfNull(message);
        message.MessageRead();
        return message.MessageRead().Result;
    }
}