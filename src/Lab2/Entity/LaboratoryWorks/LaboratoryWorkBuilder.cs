using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectNumberOfPoints;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;

public class LaboratoryWorkBuilder
{
    private Id? _id;
    private string? _name;
    private string? _description;
    private string? _evaluationCriteria;
    private NumberOfPoints? _numberOfPoints;
    private User? _creator;

    public LaboratoryWorkBuilder AddId(Id id)
    {
        _id = id;
        return this;
    }

    public LaboratoryWorkBuilder AddName(string name)
    {
        _name = name;
        return this;
    }

    public LaboratoryWorkBuilder AddDescription(string description)
    {
        _description = description;
        return this;
    }

    public LaboratoryWorkBuilder AddEvaluationCriteria(string evaluationCriteria)
    {
        _evaluationCriteria = evaluationCriteria;
        return this;
    }

    public LaboratoryWorkBuilder AddNumberOfPoints(NumberOfPoints numberOfPoints)
    {
        _numberOfPoints = numberOfPoints;
        return this;
    }

    public LaboratoryWorkBuilder AddCreator(User creator)
    {
        _creator = creator;
        return this;
    }

    public LaboratoryWork BuildLaboratoryWork()
    {
        if (_id == null)
        {
            throw new InvalidOperationException("ID must be provided.");
        }

        if (string.IsNullOrWhiteSpace(_name))
        {
            throw new InvalidOperationException("Name must be provided.");
        }

        if (string.IsNullOrWhiteSpace(_description))
        {
            throw new InvalidOperationException("Description must be provided.");
        }

        if (_numberOfPoints == null)
        {
            throw new InvalidOperationException("Number of points must be provided.");
        }

        if (string.IsNullOrWhiteSpace(_evaluationCriteria))
        {
            throw new InvalidOperationException("Evaluation criteria must be provided.");
        }

        if (_creator is null)
        {
            throw new InvalidOperationException("Creator must be provided.");
        }

        return new LaboratoryWork(_id, _name, _description, _evaluationCriteria, _numberOfPoints, _creator);
    }
}
