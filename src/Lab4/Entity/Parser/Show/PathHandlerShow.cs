namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Handlers;

public class PathHandlerShow : ICommandHandler
{
    public bool CanHandle(string[] parts)
    {
        return parts.Length >= 3 && parts[0] == "file" && parts[1] == "show";
    }

    public void Handle(string[] parts, ParsingResultShow resultShow)
    {
        resultShow.SetPath(parts[2]);
    }
}