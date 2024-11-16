using Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;
using static Itmo.ObjectOrientedProgramming.Lab2.ValueObject.ValueObjectId;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Repository;

public class LectureMaterialRepository : ILectureMaterialRepository
{
    private readonly Dictionary<Id, LectureMaterial> _lectureMaterials;

    public LectureMaterialRepository()
    {
        _lectureMaterials = new Dictionary<Id, LectureMaterial>();
    }

    public LectureMaterial? Add(LectureMaterial lectureMaterial)
    {
        if (_lectureMaterials.ContainsKey(lectureMaterial.Id))
        {
            return null;
        }

        _lectureMaterials[lectureMaterial.Id] = lectureMaterial;
        return lectureMaterial;
    }

    public LectureMaterial? Delete(Id id)
    {
        if (_lectureMaterials.TryGetValue(id, out LectureMaterial? lectureMaterial))
        {
            _lectureMaterials.Remove(id);
            return lectureMaterial;
        }

        return null;
    }

    public LectureMaterial? GetById(Id id)
    {
        if (_lectureMaterials.TryGetValue(id, out LectureMaterial? lectureMaterial))
        {
            return lectureMaterial;
        }

        return null;
    }
}