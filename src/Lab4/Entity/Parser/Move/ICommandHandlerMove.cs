namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Move;

public interface ICommandHandlerMove
{
    bool CanHandle(string[] parts);

    void Handle(string[] parts, ParsingResultMove result);
}