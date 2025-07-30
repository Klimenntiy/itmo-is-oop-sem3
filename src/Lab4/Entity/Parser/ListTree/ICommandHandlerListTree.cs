namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.ListTree;

public interface ICommandHandlerListTree
{
    bool CanHandle(string[] parts);

    void Handle(string[] parts, ParsingResultListTree result);
}