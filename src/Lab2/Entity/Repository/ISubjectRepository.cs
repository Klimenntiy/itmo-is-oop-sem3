using Itmo.ObjectOrientedProgramming.Lab2.Entity.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public interface ISubjectRepository
{
    Subject? Add(Subject subject);

    Subject? Delete(ValueObjectId id);

    Subject? GetById(ValueObjectId id);
}