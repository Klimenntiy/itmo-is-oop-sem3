using Itmo.ObjectOrientedProgramming.Lab2.Entity.Programs;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public class ProgramRepository : IProgramRepository
{
    private readonly Dictionary<Id, Program> _programs;

    public ProgramRepository()
    {
        _programs = new Dictionary<Id, Program>();
    }

    public Program? Add(Program program)
    {
        if (_programs.ContainsKey(program.Id))
        {
            return null;
        }

        _programs[program.Id] = program;
        return program;
    }

    public Program? Delete(Id id)
    {
        if (_programs.TryGetValue(id, out Program? program))
        {
            _programs.Remove(id);
            return program;
        }

        return null;
    }

    public Program? GetById(Id id)
    {
        if (_programs.TryGetValue(id, out Program? program))
        {
            return program;
        }

        return null;
    }
}