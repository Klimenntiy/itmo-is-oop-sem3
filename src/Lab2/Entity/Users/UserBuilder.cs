using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;

public class UserBuilder
{
    private string? _name;
    private Id? _id;

    public UserBuilder AddName(string name)
    {
        _name = name;
        return this;
    }

    public UserBuilder AddId(Id id)
    {
        _id = id;
        return this;
    }

    public User BuildUser()
    {
        if (string.IsNullOrEmpty(_name))
        {
            throw new InvalidOperationException("Name must be provided.");
        }

        if (_id == null)
        {
            throw new InvalidOperationException("ID must be provided.");
        }

        return new User(_name, _id);
    }
}