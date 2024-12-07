using Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;

public class DeleteCommand : ICommand
{
    private readonly string _filePath;

    public DeleteCommand(string filePath)
    {
        _filePath = filePath;
    }

    public void Execute(SystemEnvironment systemEnvironment)
    {
        if (systemEnvironment != null)
            systemEnvironment.RemoveFile(_filePath);
    }
}