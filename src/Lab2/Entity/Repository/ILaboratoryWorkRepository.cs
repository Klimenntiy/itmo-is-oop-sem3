using Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public interface ILaboratoryWorkRepository
{
    LaboratoryWork? Add(LaboratoryWork laboratoryWork);

    LaboratoryWork? Delete(Id id);

    LaboratoryWork? GetById(Id id);
}
