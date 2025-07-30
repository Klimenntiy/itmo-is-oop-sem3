namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;

public class ModifyResult
{
    public bool Importance { get; }

    public FinalResult Res { get; }

    public ModifyResult(FinalResult res, bool importance)
    {
        Res = res;
        Importance = importance;
    }
}