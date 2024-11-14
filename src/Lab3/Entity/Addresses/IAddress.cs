using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;

public interface IAddress
{
    public FinalResult AcceptMessage(Message message);
}