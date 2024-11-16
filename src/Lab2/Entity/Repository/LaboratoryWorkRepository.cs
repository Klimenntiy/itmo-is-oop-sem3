using Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public class LaboratoryWorkRepository : ILaboratoryWorkRepository
{
    private readonly Dictionary<Id, LaboratoryWork> _laboratoryWorks;

    public LaboratoryWorkRepository()
    {
        _laboratoryWorks = new Dictionary<Id, LaboratoryWork>();
    }

    public bool Add(LaboratoryWork laboratoryWork)
    {
        if (_laboratoryWorks.ContainsKey(laboratoryWork.Id))
        {
            return false;
        }

        _laboratoryWorks[laboratoryWork.Id] = laboratoryWork;
        return true;
    }

    public void Delete(Id id)
    {
        if (!_laboratoryWorks.Remove(id))
        {
            throw new InvalidOperationException($"LaboratoryWork with id {id} does not exist.");
        }
    }

    public LaboratoryWork GetById(Id id)
    {
        if (_laboratoryWorks.TryGetValue(id, out LaboratoryWork? laboratoryWork))
        {
            return laboratoryWork;
        }

        throw new InvalidOperationException($"LaboratoryWork with id {id} does not exist.");
    }
}