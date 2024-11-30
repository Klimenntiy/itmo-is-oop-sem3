namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Displays;

public class Display
{
    public Display(string name, string title, string currentMessage)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Title = title ?? throw new ArgumentNullException(nameof(title));
        CurrentMessage = currentMessage;
    }

    public string CurrentMessage { get; private set; }

    public string Name { get; private set; }

    public string Title { get; private set; }

    public void AcceptMessage(string message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        CurrentMessage = message;
    }
}