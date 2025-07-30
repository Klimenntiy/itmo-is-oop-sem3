namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.GoToTree;

public class ParsingResultGoToTree
{
    public string Path { get; private set; }

    public ParsingResultGoToTree()
    {
        Path = string.Empty;
    }

    public void SetPath(string path)
    {
        Path = path;
    }
}