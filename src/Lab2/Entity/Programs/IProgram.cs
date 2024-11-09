using Itmo.ObjectOrientedProgramming.Lab2.Entity.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectSemestr;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Programs;

public interface IProgram
{
    public Id Id { get; }

    public string Name { get; }

    public IReadOnlyCollection<Subject> Subjects { get; }

    public Semestr Semestr { get; }

    public User Director { get;  }
}