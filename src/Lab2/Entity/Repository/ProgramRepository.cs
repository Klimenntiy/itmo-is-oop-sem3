using Itmo.ObjectOrientedProgramming.Lab2.Entity.Programs;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public class ProgramRepository : IProgramRepository
{
    private readonly List<Program> _programs;

    public ProgramRepository()
    {
        _programs = new List<Program>();
    }

    public Program? Add(Program program)
    {
        if (_programs.Any(p => p.Id.Equals(program.Id)))
        {
            return null;
        }

        _programs.Add(program);
        return program;
    }

    public Program? Delete(ValueObjectId id)
    {
        Program? program = _programs.FirstOrDefault(p => p.Id.Equals(id));
        if (program != null)
        {
            _programs.Remove(program);
            return program;
        }

        return null;
    }

    public Program? GetById(ValueObjectId id)
    {
        return _programs.FirstOrDefault(p => p.Id.Equals(id));
    }
}