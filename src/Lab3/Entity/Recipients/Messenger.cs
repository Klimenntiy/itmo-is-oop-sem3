using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Recipients;

public class Messenger
{
    public Messenger(string name, string title)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name), "Имя не может быть null.");
        Title = title ?? throw new ArgumentNullException(nameof(title), "Заголовок не может быть null.");
    }

    public Messenger(Messenger messenger)
    {
        Name = messenger.Name;
        Title = messenger.Title;
    }

    private Message? CurrentMessage { get; set; }

    private string Name { get; }

    private string Title { get; }

    public void AcceptMessage(Message message)
    {
        CurrentMessage = message;
    }

    public void Print()
    {
        if (CurrentMessage != null)
        {
            Console.WriteLine(CurrentMessage);
        }
        else
        {
            Console.WriteLine("No message to show");
        }
    }
}