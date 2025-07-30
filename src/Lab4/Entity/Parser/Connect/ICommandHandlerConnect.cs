namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Connect;

public interface ICommandHandlerConnect
{
    bool CanHandle(string[] parts);

    void Handle(string[] parts, ParsingResultConnect result);
}