namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;

public interface IMessage
{
    public IMessage Clone();

    int Priority { get; }

    string Body { get; }
}