namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Move;

public class SourcePathHandlerMove : ICommandHandlerMove
{
    public bool CanHandle(string[] parts)
    {
        return parts.Length >= 3 && parts[0] == "file" && parts[1] == "move";
    }

    public void Handle(string[] parts, ParsingResultMove result)
    {
        result.SetSourcePath(parts[2]);
    }
}