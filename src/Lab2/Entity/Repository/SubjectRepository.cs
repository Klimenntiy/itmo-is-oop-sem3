using Itmo.ObjectOrientedProgramming.Lab2.Entity.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public class SubjectRepository : ISubjectRepository
{
    private readonly List<Subject> _subjects;

    public SubjectRepository()
    {
        _subjects = new List<Subject>();
    }

    public Subject? Add(Subject subject)
    {
        if (_subjects.Any(s => s.Id.Equals(subject.Id)))
        {
            return null;
        }

        _subjects.Add(subject);
        return subject;
    }

    public Subject? Delete(ValueObjectId id)
    {
        Subject? subjectToRemove = _subjects.FirstOrDefault(s => s.Id.Equals(id));
        if (subjectToRemove != null)
        {
            _subjects.Remove(subjectToRemove);
            return subjectToRemove;
        }

        return null;
    }

    public Subject? GetById(ValueObjectId id)
    {
        return _subjects.FirstOrDefault(s => s.Id.Equals(id));
    }
}