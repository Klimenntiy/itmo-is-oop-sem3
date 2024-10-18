using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

public class StationArea : IArea
{
    public StationArea(uint distance, uint stopSpeed, uint stopTime)
    {
        _distance = distance;
        _stopSpeed = stopSpeed;
        _stopTime = stopTime;
    }

    private readonly uint _stopSpeed;

    private readonly uint _stopTime;

    private long _distance;

    public Result Move(Train train)
    {
        if (train.Speed > _stopSpeed)
        {
            return new Result.TheStationDidNotStopTheTrain();
        }

        train.Time += _stopTime;
        while (_distance > 0)
        {
            long resultSpeed = (long)(train.Speed + (train.Acceleration * train.Aim));
            long resultDistance = resultSpeed * train.Aim;
            _distance -= resultDistance;
            train.Distance += resultDistance;
        }

        return new Result.Success(train.Time);
    }
}