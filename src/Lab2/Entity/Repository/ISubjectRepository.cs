using Itmo.ObjectOrientedProgramming.Lab2.Entity.Subjects;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public interface ISubjectRepository
{
    bool Add(Subject subject);

    void Delete(Id id);

    Subject GetById(Id id);
}