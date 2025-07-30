namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Rename;

public interface ICommandHandlerRename
{
    bool CanHandle(string[] parts);

    void Handle(string[] parts, ParsingResultRename result);
}