using Itmo.ObjectOrientedProgramming.Lab2.Entity.Subjects;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public class SubjectRepository : ISubjectRepository
{
    private readonly Dictionary<Id, Subject> _subjects;

    public SubjectRepository()
    {
        _subjects = new Dictionary<Id, Subject>();
    }

    public Subject? Add(Subject subject)
    {
        if (_subjects.ContainsKey(subject.Id))
        {
            return null;
        }

        _subjects[subject.Id] = subject;
        return subject;
    }

    public Subject? Delete(Id id)
    {
        if (_subjects.TryGetValue(id, out Subject? subject))
        {
            _subjects.Remove(id);
            return subject;
        }

        return null;
    }

    public Subject? GetById(Id id)
    {
        if (_subjects.TryGetValue(id, out Subject? subject))
        {
            return subject;
        }

        return null;
    }
}