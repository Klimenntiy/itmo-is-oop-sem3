using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

public class PowerArea : IArea
{
    private readonly float _power;

    public PowerArea(long distance, float power)
    {
        Distance = distance;
        _power = power;
    }

    public long Distance { get; set; }

    public Result Move(Train train)
    {
        train.Acceleration = _power / train.Weight;

        train.Time += Math.Sqrt(2.0 * Distance / double.Abs(train.Acceleration));

        if (train.PowerOn < _power)
        {
            return new Result.TheTrainCouldntHandleTheAcceleration();
        }

        while (Distance > 0)
        {
            train.Speed = (long)(train.Speed + (train.Acceleration * train.Aim));
            if (train.Speed <= 0)
            {
                return new Result.TheTrainHasNoSpeed();
            }

            long resultDistance = train.Speed * train.Aim;
            Distance -= resultDistance;
            train.Distance += resultDistance;
        }

        return new Result.Success(train.Time);
    }
}