namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Delete;

public class PathHandlerDelete : ICommandHandlerDelete
{
    public bool CanHandle(string[] parts)
    {
        return parts.Length >= 3 && parts[0] == "file" && parts[1] == "delete";
    }

    public void Handle(string[] parts, ParsingResultDelete result)
    {
        result.SetPath(parts[2]);
    }
}