using Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Subjects;

public interface ISubject
{
    public string Name { get; }

    public Id Id { get; }

    public IReadOnlyList<LaboratoryWork> LabWorks { get; }

    public IReadOnlyList<LectureMaterial> LecMaterials { get; }

    public User Creator { get; }

    public string TypeOfCredit { get; }

    public string Points { get; }
}