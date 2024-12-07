using Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;

public class CopyCommand : ICommand
{
    private readonly string _originPath;
    private readonly string _targetPath;

    public CopyCommand(string originPath, string targetPath)
    {
        _originPath = originPath;
        _targetPath = targetPath;
    }

    public void Execute(SystemEnvironment systemEnvironment)
    {
        if (systemEnvironment != null)
            systemEnvironment.DuplicateFile(_originPath, _targetPath);
    }
}