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

    public void Add(Subject subject)
    {
        if (_subjects.ContainsKey(subject.Id))
            throw new InvalidOperationException($"Subject with id {subject.Id} already exists.");
        _subjects[subject.Id] = subject;
    }

    public void Delete(Id id)
    {
        if (!_subjects.Remove(id))
        {
            throw new InvalidOperationException($"Subject with id {id} does not exist.");
        }
    }

    public Subject GetById(Id id)
    {
        if (_subjects.TryGetValue(id, out Subject? subject))
        {
            return subject;
        }

        throw new InvalidOperationException($"Subject with id {id} does not exist.");
    }
}