using Itmo.ObjectOrientedProgramming.Lab2.Entity.LaboratoryWorks;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Model;

public class ModifyResultLab
{
    public LaboratoryWork? LaboratoryWork { get; }

    public FinalResult Res { get; }

    public ModifyResultLab(LaboratoryWork? laboratoryWork, FinalResult res)
    {
        LaboratoryWork = laboratoryWork;
        Res = res;
    }
}