using Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public class LectureMaterialRepository : ILectureMaterialRepository
{
    private readonly List<LectureMaterial> _lectureMaterials;

    public LectureMaterialRepository()
    {
        _lectureMaterials = new List<LectureMaterial>();
    }

    public LectureMaterial? Add(LectureMaterial lectureMaterial)
    {
        if (_lectureMaterials.Any(lm => lm.Equals(lectureMaterial)))
        {
            return null;
        }

        _lectureMaterials.Add(lectureMaterial);
        return lectureMaterial;
    }

    public LectureMaterial? Delete(ValueObjectId id)
    {
        LectureMaterial? materialToRemove = _lectureMaterials.FirstOrDefault(lm => lm.Id.Equals(id));
        if (materialToRemove != null)
        {
            _lectureMaterials.Remove(materialToRemove);
            return materialToRemove;
        }

        return null;
    }

    public LectureMaterial? GetById(ValueObjectId id)
    {
        return _lectureMaterials.FirstOrDefault(lm => lm.Id.Equals(id));
    }
}