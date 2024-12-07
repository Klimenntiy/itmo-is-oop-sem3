namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Disconnect;

public class DisconnectHandler : ICommandHandlerDisconnect
{
    public bool CanHandle(string[] parts)
    {
        return parts.Length == 1 && parts[0] == "disconnect";
    }
}