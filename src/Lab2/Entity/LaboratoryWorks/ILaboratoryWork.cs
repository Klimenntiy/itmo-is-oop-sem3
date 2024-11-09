using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectNumberOfPoints;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;

public interface ILaboratoryWork
{
    public Id Id { get; }

    public string Name { get; }

    public string Description { get;  }

    public string EvaluationCriteria { get; }

    public NumberOfPoints NumberOfPoints { get;  }

    public User Creator { get;  }
}