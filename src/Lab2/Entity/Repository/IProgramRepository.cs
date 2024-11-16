using Itmo.ObjectOrientedProgramming.Lab2.Entity.Programs;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public interface IProgramRepository
{
    Program? Add(Program program);

    Program? Delete(Id id);

    Program? GetById(Id id);
}