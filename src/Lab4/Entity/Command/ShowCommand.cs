using Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;

public class ShowCommand : ICommand
{
    private readonly string _filePath;

    public ShowCommand(string filePath)
    {
        _filePath = filePath;
    }

    public void Execute(SystemEnvironment systemEnvironment)
    {
        if (systemEnvironment != null)
        {
            systemEnvironment.SwitchToTextShow(new ContentShow(new Writer()));
            systemEnvironment.DisplayFileContent(_filePath);
        }
    }
}