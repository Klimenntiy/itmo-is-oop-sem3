namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Delete;

public interface ICommandHandlerDelete
{
    bool CanHandle(string[] parts);

    void Handle(string[] parts, ParsingResultDelete result);
}