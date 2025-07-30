using Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser;

public interface IParser
{
    IParser? SetNext(IParser nextHandler);

    ICommand? Parse(string command);
}