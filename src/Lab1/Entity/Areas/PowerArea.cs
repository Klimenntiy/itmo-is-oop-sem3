using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

public class PowerArea(double distance, double power) : BaseArea(distance)
{
    private double Power { get; } = power;

    public override Result Move(Train train)
    {
        double currentSpeed = train.Speed;
        train.Acceleration = Power / train.Weight;
        train.Time = Math.Sqrt(2 * Distance / train.Acceleration);
        train.Speed = (train.Acceleration * train.Time) + currentSpeed;
        if (train.PowerOn < Power)
        {
            return new Result.TheTrainCouldntHandleTheAcceleration();
        }

        if (train.Speed <= 0)
        {
            return new Result.TheTrainHasNoSpeed();
        }

        return base.Move(train);
    }
}