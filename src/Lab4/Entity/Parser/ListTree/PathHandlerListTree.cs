namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.ListTree;

public class PathHandlerListTree : ICommandHandlerListTree
{
    public bool CanHandle(string[] parts)
    {
        return parts.Length >= 4 && parts[0] == "tree" && parts[1] == "list" && parts[2] == "-d";
    }

    public void Handle(string[] parts, ParsingResultListTree result)
    {
        if (int.TryParse(parts[3], out int depth))
            result.SetDepth(depth);
    }
}