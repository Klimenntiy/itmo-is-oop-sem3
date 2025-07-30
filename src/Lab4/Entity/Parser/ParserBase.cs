using Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser;

public abstract class ParserBase : IParser
{
    private IParser? _nextParser;

    protected IWriter Writer { get; private set; } = new Writer();

    public IParser? SetNext(IParser? nextHandler)
    {
        _nextParser = nextHandler;
        return nextHandler;
    }

    public virtual ICommand? Parse(string command)
    {
        return _nextParser?.Parse(command);
    }

    public void SetErrorWriter(IWriter writer)
    {
        Writer = writer;
    }
}