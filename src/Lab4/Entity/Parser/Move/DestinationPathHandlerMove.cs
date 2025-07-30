namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Move;

public class DestinationPathHandlerMove : ICommandHandlerMove
{
    public bool CanHandle(string[] parts)
    {
        return parts.Length >= 4 && parts[0] == "file" && parts[1] == "move";
    }

    public void Handle(string[] parts, ParsingResultMove result)
    {
        result.SetDestinationPath(parts[3]);
    }
}