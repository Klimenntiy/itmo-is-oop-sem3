using Itmo.ObjectOrientedProgramming.Lab4.Entity.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;

public class ConnectCommand : ICommand
{
    private readonly string _targetAddress;

    public ConnectCommand(string targetAddress)
    {
        _targetAddress = targetAddress;
    }

    public void Execute(SystemEnvironment systemEnvironment)
    {
        if (systemEnvironment != null)
        {
            systemEnvironment.SwitchToFileSystem(new LocalSystem(systemEnvironment));
            systemEnvironment.EstablishConnection(_targetAddress);
        }
    }
}