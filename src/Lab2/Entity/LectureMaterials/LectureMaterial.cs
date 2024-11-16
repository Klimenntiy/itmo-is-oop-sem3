using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;

public class LectureMaterial : IPrototypeLecMat<LectureMaterial>
{
    public LectureMaterial(Id id, string name, string description, string content, User creator)
    {
        Id = id;
        Name = name;
        Description = description;
        Content = content;
        Creator = creator;
    }

    public Id Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Content { get; private set; }

    public User Creator { get; private set; }

    public LectureMaterial CloneMaterial(LectureMaterial existingMaterial, string newName, string newDescription, string newContent, User newCreator)
    {
        existingMaterial.Name = newName;
        existingMaterial.Description = newDescription;
        existingMaterial.Content = newContent;
        existingMaterial.Creator = newCreator;

        return existingMaterial;
    }
}