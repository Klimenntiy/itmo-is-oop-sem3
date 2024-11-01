using Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.DistanceValue;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

public class PowerArea : IArea
{
    public PowerArea(double distanceValue, double power)
    {
        Distance = new Distance(distanceValue);
        Power = power;
    }

    private double Power { get; }

    private Distance Distance { get; }

    public Result Move(Train train)
    {
        return train.MovePowerArea(Power, Distance);
    }
}