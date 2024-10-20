using Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service;

public class TrainService
{
    public Result MoveNormalArea(Train train, int distance)
    {
        if (train.Speed <= 0)
        {
            return new TrainResult.TheTrainHasNoSpeed();
        }

        train = train with { Time = train.Time + (uint)CalculateTrainTime(train, distance) };
        while (distance > 0)
        {
            train = train with { Speed = (uint)CalculateNormalTrainSpeed(train) };
            long resultDistance = CalculateTrainResultDistance(train);
            distance -= (int)resultDistance;
            train = train with { Distance = (uint)(train.Distance + resultDistance) };
        }

        return new Result.TravelSuccessResult(train);
    }

    public Result MovePowerArea(Train train, int power, int distance)
    {
        train = train with { Acceleration = CalculateTrainAcceleration(train, power) };

        train = train with { Time = (uint)(train.Time + CalculateTrainTimeInPowerArea(train, distance)) };

        if (train.PowerOn < power)
        {
            return new TrainResult.TheTrainCouldntHandleTheAcceleration();
        }

        while (distance > 0)
        {
            train = train with { Speed = (uint)CalculatePowerTrainSpeed(train) };
            if (train.Speed <= 0)
            {
                return new TrainResult.TheTrainHasNoSpeed();
            }

            long resultDistance = CalculateTrainResultDistance(train);
            distance -= (int)resultDistance;
            train = train with { Distance = (uint)(train.Distance + resultDistance) };
        }

        return new Result.TravelSuccessResult(train);
    }

    public Result MoveStationArea(Train train, int distance, uint stopSpeed, uint stopTime)
    {
        if (train.Speed > stopSpeed)
        {
            return new AreaResult.TheStationDidNotStopTheTrain();
        }

        train = train with { Time = train.Time + stopTime };
        while (distance > 0)
        {
            train = train with { Speed = (uint)CalculateNormalTrainSpeed(train) };
            long resultDistance = CalculateTrainResultDistance(train);
            distance -= (int)resultDistance;
            train = train with { Distance = (uint)(train.Distance + resultDistance) };
        }

        return new Result.TravelSuccessResult(train);
    }

    private static float CalculateTrainAcceleration(Train train, float power)
    {
        uint weight = train.Weight;
        return power / weight;
    }

    private static float CalculateTrainTimeInPowerArea(Train train, int distance)
    {
        float acceleration = train.Acceleration;
        return (float)Math.Sqrt(2 * distance / double.Abs(acceleration));
    }

    private static long CalculateTrainTime(Train train, int distance)
    {
        uint speed = train.Speed;
        return distance / speed;
    }

    private static double CalculatePowerTrainSpeed(Train train)
    {
        double speed = train.Speed;
        float acceleration = train.Acceleration;
        uint aim = train.Aim;
        return speed + (acceleration * aim);
    }

    private static double CalculateNormalTrainSpeed(Train train)
    {
        double speed = train.Speed;
        uint aim = train.Aim;
        return speed + (0 * aim);
    }

    private static uint CalculateTrainResultDistance(Train train)
    {
        uint speed = train.Speed;
        uint aim = train.Aim;
        return speed * aim;
    }
}