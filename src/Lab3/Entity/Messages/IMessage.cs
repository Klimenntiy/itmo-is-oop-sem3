namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;

public interface IMessage
{
    public int Id { get; }

    public int Priority { get; }

    public string Header { get; }

    public string Body { get; }

    public IMessage Clone();
}