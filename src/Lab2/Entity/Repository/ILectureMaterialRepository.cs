using Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public interface ILectureMaterialRepository
{
    LectureMaterial? Add(LectureMaterial lectureMaterial);

    LectureMaterial? Delete(ValueObjectId id);

    LectureMaterial? GetById(ValueObjectId id);
}