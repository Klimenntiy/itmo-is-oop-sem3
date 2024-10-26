using Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

public class StationArea : IArea
{
    public StationArea(uint distance, uint stopSpeed, uint stopTime)
    {
        StopSpeed = stopSpeed;
        StopTime = stopTime;
        Distance = distance;
    }

    public uint StopTime { get; }

    private uint StopSpeed { get; }

    private uint Distance { get; }

    public Result Move(Train train)
    {
        return train.MoveStationArea(train, Distance, StopSpeed, StopSpeed);
    }
}