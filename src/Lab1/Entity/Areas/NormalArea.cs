using Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

public class NormalArea : IArea
{
    private uint Distance { get; }

    public NormalArea(uint distance)
    {
        Distance = distance;
    }

    public Result Move(Train train)
    {
        return train.MoveNormalArea(train, Distance);
    }
}