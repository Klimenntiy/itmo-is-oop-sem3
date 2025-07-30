namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.GoToTree;

public class PathHandlerGoToTree : ICommandHandlerGoToTree
{
    public bool CanHandle(string[] parts)
    {
        return parts.Length >= 3 && parts[0] == "tree" && parts[1] == "goto";
    }

    public void Handle(string[] parts, ParsingResultGoToTree result)
    {
        result.SetPath(parts[2]);
    }
}