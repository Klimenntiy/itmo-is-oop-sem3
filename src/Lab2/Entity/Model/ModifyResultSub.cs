using Itmo.ObjectOrientedProgramming.Lab2.Entity.Subjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Model;

public class ModifyResultSub
{
    public Subject? Subject { get; }

    public FinalResult Res { get; }

    public ModifyResultSub(Subject? subject, FinalResult res)
    {
        Subject = subject;
        Res = res;
    }
}