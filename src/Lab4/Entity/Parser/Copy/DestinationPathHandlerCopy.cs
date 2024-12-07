namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Copy;

public class DestinationPathHandlerCopy : ICommandHandlerCopy
{
    public bool CanHandle(string[] parts)
    {
        return parts.Length >= 4 && parts[0] == "file" && parts[1] == "copy";
    }

    public void Handle(string[] parts, ParsingResultCopy result)
    {
        result.SetDestinationPath(parts[3]);
    }
}