using Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Subjects;

public class Subject : IPrototypeSubject<Subject>
{
    public Subject(string name, ValueObjectId.Id id, IReadOnlyCollection<LaboratoryWork> labWorks, IReadOnlyCollection<LectureMaterial> lecMaterials, string typeOfCredit, string points, User creator)
    {
        Name = name;
        Id = id;
        LabWorks = labWorks;
        LecMaterials = lecMaterials;
        TypeOfCredit = typeOfCredit;
        Points = points;
        Creator = creator;
    }

    public string Name { get; private set; }

    public ValueObjectId.Id Id { get; private set; }

    public IReadOnlyCollection<LaboratoryWork> LabWorks { get; private set; }

    public IReadOnlyCollection<LectureMaterial> LecMaterials { get; private set; }

    public User Creator { get; private set; }

    public string TypeOfCredit { get; private set; }

    public string Points { get; private set; }

    public static FinalResult CheckOfScore(IReadOnlyCollection<LaboratoryWork> laboratoryWorks)
    {
        double totalScore = 0;

        foreach (LaboratoryWork work in laboratoryWorks)
        {
            totalScore += work.NumberOfPoints;
        }

        if (totalScore != 100)
        {
            return new FinalResult.SubjectScoresDoNotEqualAHundred();
        }

        return new FinalResult.Success();
    }

    public Subject CloneSubject(Subject existingSubject, string newName, IReadOnlyCollection<LectureMaterial> newLectureMaterials, IReadOnlyCollection<LaboratoryWork> newLabWorks, User newCreator, string newTypeOfCredit, string newPoints)
    {
        existingSubject.Name = newName;
        existingSubject.LecMaterials = newLectureMaterials;
        existingSubject.LabWorks = newLabWorks;
        existingSubject.TypeOfCredit = newTypeOfCredit;
        existingSubject.Points = newPoints;
        existingSubject.Creator = newCreator;

        return existingSubject;
    }
}