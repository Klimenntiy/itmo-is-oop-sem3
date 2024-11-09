using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;

public interface ILectureMaterial
{
    public Id Id { get; }

    public string Name { get; }

    public string Description { get; }

    public string Content { get; }

    public User Creator { get;  }
}