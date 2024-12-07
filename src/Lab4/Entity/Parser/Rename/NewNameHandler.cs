namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Rename;

public class NewNameHandler : ICommandHandlerRename
{
    public bool CanHandle(string[] parts)
    {
        return parts.Length >= 4 && parts[0] == "file" && parts[1] == "rename";
    }

    public void Handle(string[] parts, ParsingResultRename result)
    {
        result.SetNewName(parts[3]);
    }
}