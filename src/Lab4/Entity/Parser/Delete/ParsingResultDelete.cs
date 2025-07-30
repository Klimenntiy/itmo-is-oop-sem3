namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Delete;

public class ParsingResultDelete
{
    public string Path { get; private set; }

    public ParsingResultDelete()
    {
        Path = string.Empty;
    }

    public void SetPath(string path)
    {
        Path = path;
    }
}