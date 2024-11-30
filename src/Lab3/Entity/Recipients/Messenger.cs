namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Recipients;

public class Messenger
{
    public Messenger(string name, string title)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Title = title ?? throw new ArgumentNullException(nameof(title));
    }

    public string Name { get; }

    public string Title { get; }

    public void Print(string message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        Console.WriteLine($"{Name} ({Title}): {message}");
    }
}