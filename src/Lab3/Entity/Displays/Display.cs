using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Displays;

public class Display
{
    public Display(string name, string title)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Title = title ?? throw new ArgumentNullException(nameof(title));
    }

    public IMessage? CurrentMessage { get; private set; }

    public string Name { get; private set; }

    public string Title { get; private set; }

    public void AcceptMessage(IMessage message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        CurrentMessage = message;
    }
}