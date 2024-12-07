using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;

public class User
{
    public User(string name, Id id)
    {
        Name = name;
        Id = id;
    }

    public string Name { get; }

    public Id Id { get; }
}