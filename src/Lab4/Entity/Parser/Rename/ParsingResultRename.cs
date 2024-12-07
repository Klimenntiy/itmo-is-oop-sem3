namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Rename;

public class ParsingResultRename
{
    public string Path { get; private set; }

    public string NewName { get; private set; }

    public ParsingResultRename()
    {
        Path = string.Empty;
        NewName = string.Empty;
    }

    public void SetPath(string path)
    {
        Path = path;
    }

    public void SetNewName(string newName)
    {
        NewName = newName;
    }
}