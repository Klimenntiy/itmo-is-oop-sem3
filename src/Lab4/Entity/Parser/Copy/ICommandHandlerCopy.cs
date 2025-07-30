namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Copy;

public interface ICommandHandlerCopy
{
    bool CanHandle(string[] parts);

    void Handle(string[] parts, ParsingResultCopy result);
}