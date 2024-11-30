using Itmo.ObjectOrientedProgramming.Lab2.Entity.Enams;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Subjects;

public class Subject : IPrototypeSubject<Subject>
{
    public Subject(string name, Id id, IReadOnlyCollection<LaboratoryWork> labWorks, IReadOnlyCollection<LectureMaterial> lecMaterials, SubjectFormat typeOfCredit, InfoPoints points, User creator)
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

    public Id Id { get; private set; }

    public IReadOnlyCollection<LaboratoryWork> LabWorks { get; private set; }

    public IReadOnlyCollection<LectureMaterial> LecMaterials { get; private set; }

    public User Creator { get; private set; }

    public SubjectFormat TypeOfCredit { get; private set; }

    public InfoPoints Points { get; private set; }

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

    public Subject CloneSubject(
        Subject existingSubject,
        string newName,
        IReadOnlyCollection<LectureMaterial> newLectureMaterials,
        IReadOnlyCollection<LaboratoryWork> newLabWorks,
        User newCreator,
        SubjectFormat newTypeOfCredit,
        InfoPoints newPoints)
    {
        SubjectBuilder builder = CreateBuilder(existingSubject, newName, newLectureMaterials, newLabWorks, newCreator, newTypeOfCredit, newPoints);
        return builder.Build();
    }

    private SubjectBuilder CreateBuilder(
        Subject existingSubject,
        string newName,
        IReadOnlyCollection<LectureMaterial> newLectureMaterials,
        IReadOnlyCollection<LaboratoryWork> newLabWorks,
        User newCreator,
        SubjectFormat newTypeOfCredit,
        InfoPoints newPoints)
    {
        return new SubjectBuilder()
            .AddId(existingSubject.Id)
            .AddName(newName)
            .AddLectureMaterial(newLectureMaterials)
            .AddLabWork(newLabWorks)
            .AddCreator(newCreator)
            .AddTypeOfCredit(newTypeOfCredit)
            .AddPoints(newPoints);
    }
}
