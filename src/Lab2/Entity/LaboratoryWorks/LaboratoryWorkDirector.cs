using Itmo.ObjectOrientedProgramming.Lab2.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectNumberOfPoints;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;

public class LaboratoryWorkDirector
{
    private readonly LaboratoryWorkBuilder _builder;

    public LaboratoryWorkDirector(LaboratoryWorkBuilder builder)
    {
        _builder = builder;
    }

    public (LaboratoryWork? LaboratoryWork, FinalResult Res) Modify(
        LaboratoryWork existingWork,
        User creator,
        string? newName = null,
        string? newDescription = null,
        string? newEvaluationCriteria = null,
        NumberOfPoints? newNumberOfPoints = null)
    {
        if (existingWork.Creator == creator)
        {
            _builder.AddId(existingWork.Id);
            _builder.AddCreator(existingWork.Creator);

            _builder.AddName(newName ?? existingWork.Name)
                .AddDescription(newDescription ?? existingWork.Description)
                .AddEvaluationCriteria(newEvaluationCriteria ?? existingWork.EvaluationCriteria)
                .AddNumberOfPoints(newNumberOfPoints ?? existingWork.NumberOfPoints);

            return (_builder.BuildLaboratoryWork(), new FinalResult.Success());
        }

        return (null, new FinalResult.ItsNotTheAuthorWhoChangesTheEssence());
    }
}