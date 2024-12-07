using Itmo.ObjectOrientedProgramming.Lab2.Entity.Programs;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public interface IProgramRepository
{
    Program? Add(Program program);

    Program? Delete(ValueObjectId id);

    Program? GetById(ValueObjectId id);
}