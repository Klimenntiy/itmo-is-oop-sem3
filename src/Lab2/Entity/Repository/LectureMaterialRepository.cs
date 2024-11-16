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

    public bool Add(LectureMaterial lectureMaterial)
    {
        if (_lectureMaterials.ContainsKey(lectureMaterial.Id))
        {
            return false;
        }

        _lectureMaterials[lectureMaterial.Id] = lectureMaterial;
        return true;
    }

    public void Delete(Id id)
    {
        if (!_lectureMaterials.Remove(id))
        {
            throw new InvalidOperationException($"LectureMaterial with id {id} does not exist.");
        }
    }

    public LectureMaterial GetById(Id id)
    {
        if (_lectureMaterials.TryGetValue(id, out LectureMaterial? lectureMaterial))
        {
            return lectureMaterial;
        }

        throw new InvalidOperationException($"LectureMaterial with id {id} does not exist.");
    }
}