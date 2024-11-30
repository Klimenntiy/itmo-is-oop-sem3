using Itmo.ObjectOrientedProgramming.Lab2.Entity.LectureMaterials;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Model;

public class ModifyResultLec
{
    public LectureMaterial? LecMaterial { get; }

    public FinalResult Res { get; }

    public ModifyResultLec(LectureMaterial? lecMaterial, FinalResult res)
    {
        LecMaterial = lecMaterial;
        Res = res;
    }
}