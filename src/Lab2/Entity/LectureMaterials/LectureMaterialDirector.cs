using Itmo.ObjectOrientedProgramming.Lab2.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;

public class LectureMaterialDirector
{
    private readonly LectureMaterialBuilder _builder;

    public LectureMaterialDirector(LectureMaterialBuilder builder)
    {
        _builder = builder;
    }

    public (LectureMaterial? LecMaterial, FinalResult Res) Modify(
        LectureMaterial existingMaterial,
        User creator,
        string? newName = null,
        string? newDescription = null,
        string? newContent = null)
    {
        if (existingMaterial.Creator == creator)
        {
            _builder.AddId(existingMaterial.Id);
            _builder.AddCreator(existingMaterial.Creator);

            _builder.AddName(newName ?? existingMaterial.Name)
                .AddDescription(newDescription ?? existingMaterial.Description)
                .AddContent(newContent ?? existingMaterial.Content);

            return (_builder.BuildLectureMaterial(), new FinalResult.Success());
        }

        return (null, new FinalResult.ItsNotTheAuthorWhoChangesTheEssence());
    }
}