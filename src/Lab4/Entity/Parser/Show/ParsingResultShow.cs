namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Handlers;

public class ParsingResultShow
{
    public string Path { get; private set; }

    public string Mode { get; private set; }

    public ParsingResultShow()
    {
        Path = string.Empty;
        Mode = "console";
    }

    public void SetPath(string path)
    {
        Path = path;
    }

    public void SetMode(string mode)
    {
        Mode = mode;
    }
}
