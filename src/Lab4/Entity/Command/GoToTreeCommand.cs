using Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;

public class GoToTreeCommand : ICommand
{
    private readonly string _directoryPath;

    public GoToTreeCommand(string directoryPath)
    {
        _directoryPath = directoryPath;
    }

    public void Execute(SystemEnvironment systemEnvironment)
    {
        if (systemEnvironment != null)
            systemEnvironment.NavigateToDirectory(_directoryPath);
    }
}