using Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.DistanceValue;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

public class NormalArea : IArea
{
    private Distance Distance { get; }

    public NormalArea(double distanceValue)
    {
        Distance = new Distance(distanceValue);
    }

    public Result Move(Train train)
    {
        return train.MoveNormalArea(Distance);
    }
}