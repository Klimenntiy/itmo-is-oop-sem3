namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Move;

public class ParsingResultMove
{
    public string SourcePath { get; private set; }

    public string DestinationPath { get; private set; }

    public ParsingResultMove()
    {
        SourcePath = string.Empty;
        DestinationPath = string.Empty;
    }

    public void SetSourcePath(string sourcePath)
    {
        SourcePath = sourcePath;
    }

    public void SetDestinationPath(string destinationPath)
    {
        DestinationPath = destinationPath;
    }
}