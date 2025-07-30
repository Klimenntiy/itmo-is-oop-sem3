namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Rename;

public class PathHandlerRename : ICommandHandlerRename
{
    public bool CanHandle(string[] parts)
    {
        return parts.Length >= 3 && parts[0] == "file" && parts[1] == "rename";
    }

    public void Handle(string[] parts, ParsingResultRename result)
    {
        result.SetPath(parts[2]);
    }
}