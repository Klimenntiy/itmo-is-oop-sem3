using Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;

public class ListTreeCommand : ICommand
{
    private readonly int _levelDepth;

    public ListTreeCommand(int levelDepth)
    {
        if (levelDepth > 0)
            _levelDepth = levelDepth;
    }

    public void Execute(SystemEnvironment systemEnvironment)
    {
        if (systemEnvironment != null)
            systemEnvironment.DisplayTreeStructure(_levelDepth);
    }
}