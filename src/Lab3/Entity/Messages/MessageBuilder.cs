using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class MessageBuilder
{
    private string? _header;
    private string? _body;
    private int _priority;
    private int _id;

    public MessageBuilder WithHeader(string header)
    {
        _header = header;
        return this;
    }

    public MessageBuilder WithBody(string body)
    {
        _body = body;
        return this;
    }

    public MessageBuilder WithPriority(int priority)
    {
        _priority = priority;
        return this;
    }

    public MessageBuilder WithId(int id)
    {
        _id = id;
        return this;
    }

    public Message Build()
    {
        if (string.IsNullOrEmpty(_header))
            throw new InvalidOperationException("Header cannot be null or empty.");
        if (string.IsNullOrEmpty(_body))
            throw new InvalidOperationException("Body cannot be null or empty.");

        return new Message(_header, _body, _priority, _id);
    }
}