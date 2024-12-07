using Itmo.ObjectOrientedProgramming.Lab2.Entity.Enams;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Subjects;

public class SubjectBuilder
{
    private string? _name;
    private Id? _id;
    private IReadOnlyCollection<LaboratoryWork>? _labWorks;
    private IReadOnlyCollection<LectureMaterial>? _lecMaterials;
    private User? _creator;
    private SubjectFormat? _typeOfCredit;
    private InfoPoints? _points;

    public SubjectBuilder AddName(string name)
    {
        _name = name;
        return this;
    }

    public SubjectBuilder AddId(Id id)
    {
        _id = id;
        return this;
    }

    public SubjectBuilder AddLabWork(IReadOnlyCollection<LaboratoryWork> labWorks)
    {
        _labWorks = labWorks;
        return this;
    }

    public SubjectBuilder AddLectureMaterial(IReadOnlyCollection<LectureMaterial> lecMaterials)
    {
        _lecMaterials = lecMaterials;
        return this;
    }

    public SubjectBuilder AddCreator(User creator)
    {
        _creator = creator;
        return this;
    }

    public SubjectBuilder AddTypeOfCredit(SubjectFormat typeOfCredit)
    {
        _typeOfCredit = typeOfCredit;
        return this;
    }

    public SubjectBuilder AddPoints(InfoPoints points)
    {
        _points = points;
        return this;
    }

    public FinalResult CheckOfScore()
    {
        if (_labWorks == null)
        {
            return new FinalResult.SubjectScoresDoNotEqualAHundred(); // Или выбросить исключение, если это предпочтительнее
        }

        foreach (LaboratoryWork work in _labWorks)
        {
            if (work.NumberOfPoints != 100)
            {
                return new FinalResult.SubjectScoresDoNotEqualAHundred();
            }
        }

        return new FinalResult.Success();
    }

    public Subject Build()
    {
        if (string.IsNullOrWhiteSpace(_name))
        {
            throw new InvalidOperationException("Name must be provided.");
        }

        if (_id == null)
        {
            throw new InvalidOperationException("ID must be provided.");
        }

        if (_labWorks == null)
        {
            throw new InvalidOperationException("At least one laboratory work must be provided.");
        }

        if (_lecMaterials == null)
        {
            throw new InvalidOperationException("At least one lecture material must be provided.");
        }

        if (_creator == null)
        {
            throw new InvalidOperationException("Creator must be provided.");
        }

        if (_typeOfCredit == null)
        {
            throw new InvalidOperationException("Type of creator must be provided.");
        }

        if (_points == null)
        {
            throw new InvalidOperationException("Points must be provided.");
        }

        return new Subject(_name, _id, _labWorks, _lecMaterials, _typeOfCredit, _points, _creator);
    }
}
