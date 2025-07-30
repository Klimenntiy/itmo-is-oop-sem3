using Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public class LaboratoryWorkRepository : ILaboratoryWorkRepository
{
    private readonly List<LaboratoryWork> _laboratoryWorks;

    public LaboratoryWorkRepository()
    {
        _laboratoryWorks = new List<LaboratoryWork>();
    }

    public LaboratoryWork? Add(LaboratoryWork laboratoryWork)
    {
        if (_laboratoryWorks.Any(lw => lw.Id.Equals(laboratoryWork.Id)))
        {
            return null;
        }

        _laboratoryWorks.Add(laboratoryWork);
        return laboratoryWork;
    }

    public LaboratoryWork? Delete(ValueObjectId id)
    {
        LaboratoryWork? laboratoryWork = _laboratoryWorks.FirstOrDefault(lw => lw.Id.Equals(id));
        if (laboratoryWork != null)
        {
            _laboratoryWorks.Remove(laboratoryWork);
            return laboratoryWork;
        }

        return null;
    }

    public LaboratoryWork? GetById(ValueObjectId id)
    {
        return _laboratoryWorks.FirstOrDefault(lw => lw.Id.Equals(id));
    }
}