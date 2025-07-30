using Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;

public interface ICommand
{
    void Execute(SystemEnvironment systemEnvironment);
}