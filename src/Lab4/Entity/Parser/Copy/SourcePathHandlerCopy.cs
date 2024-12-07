namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Copy;

public class SourcePathHandlerCopy : ICommandHandlerCopy
{
    public bool CanHandle(string[] parts)
    {
        return parts.Length >= 3 && parts[0] == "file" && parts[1] == "copy";
    }

    public void Handle(string[] parts, ParsingResultCopy result)
    {
        result.SetSourcePath(parts[2]);
    }
}