using Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;

public class RenameCommand : ICommand
{
    private readonly string _filePath;
    private readonly string _newName;

    public RenameCommand(string filePath, string newName)
    {
        _filePath = filePath;
        _newName = newName;
    }

    public void Execute(SystemEnvironment systemEnvironment)
    {
        if (systemEnvironment != null)
            systemEnvironment.ChangeFileName(_filePath, _newName);
    }
}