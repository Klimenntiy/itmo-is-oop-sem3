using Itmo.ObjectOrientedProgramming.Lab2.Entity.Programs;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public interface IProgramRepository
{
    bool Add(Program program);

    void Delete(Id id);

    Program GetById(Id id);
}