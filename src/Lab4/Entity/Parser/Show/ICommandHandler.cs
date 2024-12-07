namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Handlers;

public interface ICommandHandler
{
    bool CanHandle(string[] parts);

    void Handle(string[] parts, ParsingResultShow resultShow);
}