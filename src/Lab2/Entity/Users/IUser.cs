using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;

public interface IUser
{
    public string Name { get; }

    public Id Id { get;  }
}