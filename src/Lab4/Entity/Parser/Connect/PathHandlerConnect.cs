namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Connect;

public class PathHandlerConnect : ICommandHandlerConnect
{
    public bool CanHandle(string[] parts)
    {
        return parts.Length >= 2 && parts[0] == "connect";
    }

    public void Handle(string[] parts, ParsingResultConnect result)
    {
        result.SetAddress(parts[1]);
    }
}