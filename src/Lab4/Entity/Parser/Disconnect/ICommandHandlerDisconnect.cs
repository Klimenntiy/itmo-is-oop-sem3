namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Disconnect;

public interface ICommandHandlerDisconnect
{
    bool CanHandle(string[] parts);
}