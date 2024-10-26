using Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

public class PowerArea : IArea
{
    public PowerArea(uint distance, int power)
    {
        Distance = distance;
        Power = power;
    }

    public int Power { get; }

    public uint Distance { get; }

    public Result Move(Train train)
    {
        return train.MovePowerArea(train, Power, Distance);
    }
}