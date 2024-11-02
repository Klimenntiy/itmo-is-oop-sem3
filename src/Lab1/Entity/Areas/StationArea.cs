using Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.DistanceValue;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.StopSpeedValue;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.StopTimeValue;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

public class StationArea : IArea
{
    public StationArea(double distanceValue, double stopSpeedValue, double stopTimeValue)
    {
        StopSpeed = new StopSpeed(stopSpeedValue);
        StopTime = new StopTime(stopTimeValue);
        Distance = new Distance(distanceValue);
    }

    private StopTime StopTime { get; }

    private StopSpeed StopSpeed { get; }

    private Distance Distance { get; }

    public FinalResult Move(Train train)
    {
        return train.MoveStationArea(Distance, StopSpeed, StopTime);
    }
}