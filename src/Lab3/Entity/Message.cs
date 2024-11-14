namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public class Message
{
    public Message(string header, string body, int priority, int id)
    {
        Header = header;
        Body = body;
        Priority = priority;
        Id = id;
    }

    public int Id { get; }

    public int Priority { get; }

    public string Header { get; }

    public string Body { get; }
}