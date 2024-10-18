using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

public class NormalArea : IArea
{
    private long _distance;

    public NormalArea(long distance)
    {
        _distance = distance;
    }

    public Result Move(Train train)
    {
        if (train.Speed <= 0)
        {
            return new Result.TheTrainHasNoSpeed();
        }

        train.Time += _distance / train.Speed;
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