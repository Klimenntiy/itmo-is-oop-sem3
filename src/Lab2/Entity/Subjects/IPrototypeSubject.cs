using Itmo.ObjectOrientedProgramming.Lab2.Entity.Enams;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Subjects;

public interface IPrototypeSubject<T> where T : IPrototypeSubject<T>
{
    T CloneSubject(
        T existingSubject,
        string newName,
        IReadOnlyCollection<LectureMaterial> newLectureMaterials,
        IReadOnlyCollection<LaboratoryWork> newLabWorks,
        User newCreator,
        EnumToCredit newTypeOfCredit,
        EnumToExam newPoints);
}