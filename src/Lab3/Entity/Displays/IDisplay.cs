using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Displays;

public interface IDisplay
{
    public void Show(Message message);
}