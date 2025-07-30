namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.GoToTree;

public interface ICommandHandlerGoToTree
{
    bool CanHandle(string[] parts);

    void Handle(string[] parts, ParsingResultGoToTree result);
}