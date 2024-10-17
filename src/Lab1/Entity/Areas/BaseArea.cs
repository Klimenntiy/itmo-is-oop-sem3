using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

public abstract class BaseArea(double distance)
{
    protected double Distance { get; set; } = distance;

    public virtual Result Move(Train train)
    {
        while (Distance > 0)
        {
            double resultSpeed = train.Speed + (train.Acceleration * train.Aim);
            double resultDistance = resultSpeed * train.Aim;
            Distance -= resultDistance;
            train.Distance += resultDistance;
        }

        return new Result.Success();
    }
}