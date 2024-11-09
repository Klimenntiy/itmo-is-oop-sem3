using Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Subjects;

public class Subject
{
    public Subject(string name, Id id, IReadOnlyCollection<LaboratoryWork> labWorks, IReadOnlyCollection<LectureMaterial> lecMaterials, string typeOfCredit, string points, User creator)
    {
        Name = name;
        Id = id;
        LabWorks = labWorks;
        LecMaterials = lecMaterials;
        TypeOfCredit = typeOfCredit;
        Points = points;
        Creator = creator;
    }

    public string Name { get; }

    public Id Id { get; }

    public IReadOnlyCollection<LaboratoryWork> LabWorks { get; }

    public IReadOnlyCollection<LectureMaterial> LecMaterials { get; }

    public User Creator { get; }

    public string TypeOfCredit { get; }

    public string Points { get; }

    public static Subject CloneSubject(Subject existingSubject, string newName, IReadOnlyCollection<LectureMaterial> newLectureMaterials, IReadOnlyCollection<LaboratoryWork> newLabWorks, User newCreator, string newTypeOfCredit, string newPoints)
    {
        var newSubject = new Subject(
            newName,
            existingSubject.Id,
            newLabWorks,
            newLectureMaterials,
            newTypeOfCredit,
            newPoints,
            newCreator);

        return newSubject;
    }

    public static FinalResult CheckOfScore(IReadOnlyCollection<LaboratoryWork> laboratoryWorks)
    {
        foreach (LaboratoryWork work in laboratoryWorks)
        {
            if (work.NumberOfPoints != 100)
            {
                return new FinalResult.SubjectScoresDoNotEqualAHundred();
            }
        }

        return new FinalResult.Success();
    }
}