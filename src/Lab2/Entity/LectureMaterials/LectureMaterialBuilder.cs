using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;

public class LectureMaterialBuilder
{
    private Id? _id;
    private string? _name;
    private string? _description;
    private string? _content;
    private User? _creator;

    public LectureMaterialBuilder AddId(Id id)
    {
        _id = id;
        return this;
    }

    public LectureMaterialBuilder AddName(string name)
    {
        _name = name;
        return this;
    }

    public LectureMaterialBuilder AddDescription(string description)
    {
        _description = description;
        return this;
    }

    public LectureMaterialBuilder AddContent(string content)
    {
        _content = content;
        return this;
    }

    public LectureMaterialBuilder AddCreator(User creator)
    {
        _creator = creator;
        return this;
    }

    public LectureMaterial BuildLectureMaterial()
    {
        if (_id == null)
        {
            throw new InvalidOperationException("ID must be provided.");
        }

        if (string.IsNullOrWhiteSpace(_name))
        {
            throw new InvalidOperationException("Name must be provided.");
        }

        if (string.IsNullOrWhiteSpace(_description))
        {
            throw new InvalidOperationException("Description must be provided.");
        }

        if (string.IsNullOrWhiteSpace(_content))
        {
            throw new InvalidOperationException("Content must be provided.");
        }

        if (_creator == null)
        {
            throw new InvalidOperationException("Creator must be provided.");
        }

        if (_id <= 0)
        {
            throw new InvalidOperationException("ID must be greater than zero.");
        }

        return new LectureMaterial(_id, _name, _description, _content, _creator);
    }
}