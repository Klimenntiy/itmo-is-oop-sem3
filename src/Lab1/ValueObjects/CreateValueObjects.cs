using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.AimValue;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.DistanceValue;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.PowerOnValue;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.SpeedValue;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.TimeValue;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.WeightValue;

namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public static class CreateValueObjects
{
    public static Speed CreateSpeed(double speedValue)
    {
        return new Speed(speedValue);
    }

    public static Aim CreateAim(double aimValue)
    {
        return new Aim(aimValue);
    }

    public static Time CreateTime(double timeValue)
    {
        return new Time(timeValue);
    }

    public static Weight CreateWeight(double weightValue)
    {
        return new Weight(weightValue);
    }

    public static PowerOn CreatePowerOn(double powerOnValue)
    {
        return new PowerOn(powerOnValue);
    }

    public static Distance CreateDistance(double distanceValue)
    {
        return new Distance(distanceValue);
    }
}