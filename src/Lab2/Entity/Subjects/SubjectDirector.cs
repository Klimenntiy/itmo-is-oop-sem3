using Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab2.Entity.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Subjects;

public class SubjectDirector
{
    private readonly SubjectBuilder _builder;

    public SubjectDirector(SubjectBuilder builder)
    {
        _builder = builder;
    }

    public (Subject? Sub, FinalResult Res) Modify(
        Subject existingSubject,
        User creator,
        string? newName = null,
        IReadOnlyCollection<LectureMaterial>? newLecMaterials = null,
        string? newTypeOfCredit = null,
        string? newPoints = null)
    {
        if (existingSubject.Creator == creator)
        {
            _builder.AddName(newName ?? existingSubject.Name)
                .AddLectureMaterial(newLecMaterials ?? existingSubject.LecMaterials)
                .AddTypeOfCredit(newTypeOfCredit ?? existingSubject.TypeOfCredit)
                .AddPoints(newPoints ?? existingSubject.Points);

            return (_builder.Build(), new FinalResult.Success());
        }

        return (null, new FinalResult.ItsNotTheAuthorWhoChangesTheEssence());
    }
}