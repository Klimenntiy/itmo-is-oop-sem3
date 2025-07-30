namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Copy;

public class ParsingResultCopy
{
    public string SourcePath { get; private set; }

    public string DestinationPath { get; private set; }

    public ParsingResultCopy()
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