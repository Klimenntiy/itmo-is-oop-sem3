using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;

public class LectureMaterial
{
    public LectureMaterial(Id id, string name, string description, string content, User creator)
    {
        Id = id;
        Name = name;
        Description = description;
        Content = content;
        Creator = creator;
    }

    public Id Id { get; }

    public string Name { get; }

    public string Description { get; }

    public string Content { get; }

    public User Creator { get;  }

    public LectureMaterial CloneMaterial(LectureMaterial existingMaterial, string newName, string newDescription, string newContent, User newCreator)
    {
        var newMaterial = new LectureMaterial(
            existingMaterial.Id,
            newName,
            newDescription,
            newContent,
            newCreator);

        return newMaterial;
    }
}