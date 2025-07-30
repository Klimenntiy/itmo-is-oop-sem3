namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Handlers;

public class ModeHandlerShow : ICommandHandler
{
    public bool CanHandle(string[] parts)
    {
        return parts.Length >= 5 && parts[3] == "-m";
    }

    public void Handle(string[] parts, ParsingResultShow resultShow)
    {
        resultShow.SetMode(parts[4]);
    }
}