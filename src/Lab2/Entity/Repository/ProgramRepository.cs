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

    public void Add(Program program)
    {
        if (_programs.ContainsKey(program.Id))
            throw new InvalidOperationException($"Program with id {program.Id} already exists.");
        _programs[program.Id] = program;
    }

    public void Delete(Id id)
    {
        if (!_programs.Remove(id))
        {
            throw new InvalidOperationException($"Program with id {id} does not exist.");
        }
    }

    public Program GetById(Id id)
    {
        if (_programs.TryGetValue(id, out Program? program))
        {
            return program;
        }

        throw new InvalidOperationException($"Program with id {id} does not exist.");
    }
}