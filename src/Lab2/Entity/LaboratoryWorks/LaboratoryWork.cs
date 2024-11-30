using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectNumberOfPoints;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;

public class LaboratoryWork : IPrototypeLabWork<LaboratoryWork>
{
    public LaboratoryWork(Id id, string name, string description, string evaluationCriteria, NumberOfPoints numberOfPoints, User creator)
    {
        Id = id;
        Name = name;
        Description = description;
        EvaluationCriteria = evaluationCriteria;
        NumberOfPoints = numberOfPoints;
        Creator = creator;
    }

    public Id Id { get; }

    public string Name { get; }

    public string Description { get; }

    public string EvaluationCriteria { get; }

    public NumberOfPoints NumberOfPoints { get; }

    public User Creator { get; }

    public LaboratoryWork CloneWork(
        LaboratoryWork existingWork,
        string newName,
        User newCreator,
        string newDescription,
        string newEvaluationCriteria,
        NumberOfPoints newNumberOfPoints)
    {
        LaboratoryWorkBuilder builder = new LaboratoryWorkBuilder()
            .AddId(existingWork.Id)
            .AddName(newName)
            .AddDescription(newDescription)
            .AddEvaluationCriteria(newEvaluationCriteria)
            .AddNumberOfPoints(newNumberOfPoints)
            .AddCreator(newCreator);

        return builder.BuildLaboratoryWork();
    }
}