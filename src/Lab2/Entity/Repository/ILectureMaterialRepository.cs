using Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public interface ILectureMaterialRepository
{
    void Add(LectureMaterial lectureMaterial);

    void Delete(Id id);

    LectureMaterial GetById(Id id);
}