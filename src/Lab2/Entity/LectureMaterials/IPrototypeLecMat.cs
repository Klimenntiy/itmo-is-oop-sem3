using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;

public interface IPrototypeLecMat<T> where T : IPrototypeLecMat<T>
{
    T CloneMaterial(
        T existingMaterial,
        string newName,
        string newDescription,
        string newContent,
        User newCreator);
}