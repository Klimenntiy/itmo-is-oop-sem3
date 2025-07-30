using Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public interface ILaboratoryWorkRepository
{
    LaboratoryWork? Add(LaboratoryWork laboratoryWork);

    LaboratoryWork? Delete(ValueObjectId id);

    LaboratoryWork? GetById(ValueObjectId id);
}
