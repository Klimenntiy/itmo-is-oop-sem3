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

    public LaboratoryWork? Add(LaboratoryWork laboratoryWork)
    {
        if (_laboratoryWorks.ContainsKey(laboratoryWork.Id))
        {
            return null;
        }

        _laboratoryWorks[laboratoryWork.Id] = laboratoryWork;
        return laboratoryWork;
    }

    public LaboratoryWork? Delete(Id id)
    {
        if (_laboratoryWorks.TryGetValue(id, out LaboratoryWork? laboratoryWork))
        {
            _laboratoryWorks.Remove(id);
            return laboratoryWork;
        }

        return null;
    }

    public LaboratoryWork? GetById(Id id)
    {
        if (_laboratoryWorks.TryGetValue(id, out LaboratoryWork? laboratoryWork))
        {
            return laboratoryWork;
        }

        return null;
    }
}