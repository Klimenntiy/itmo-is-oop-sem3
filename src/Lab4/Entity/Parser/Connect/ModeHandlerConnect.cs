namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Connect;

public class ModeHandlerConnect : ICommandHandlerConnect
{
    public bool CanHandle(string[] parts)
    {
        return parts.Length >= 4 && parts[2] == "-m";
    }

    public void Handle(string[] parts, ParsingResultConnect result)
    {
        result.SetMode(parts[3]);
    }
}