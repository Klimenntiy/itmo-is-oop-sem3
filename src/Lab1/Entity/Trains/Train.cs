using Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.AimValue;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.DistanceValue;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.PowerOnValue;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.SpeedValue;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.TimeValue;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.WeightValue;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;

public class Train
{
    public Weight Weight { get; }

    public Speed Speed { get; private set; }

    public double Acceleration { get; private set; }

    public Time Time { get; private set; }

    public PowerOn PowerOn { get; }

    public Aim Aim { get; }

    public Distance Distance { get; private set; }

    public Train(double weightValue, double speedValue, double acceleration, double timeValue, double powerOnValue, double aimValue, double distanceValue)
    {
        Weight = new Weight(weightValue);
        Speed = new Speed(speedValue);
        Acceleration = acceleration;
        Time = new Time(timeValue);
        PowerOn = new PowerOn(powerOnValue);
        Aim = new Aim(aimValue);
        Distance = new Distance(distanceValue);
    }

    public Result MoveNormalArea(double distance)
    {
        if (Speed <= 0)
        {
            return new TrainResult.TheTrainHasNoSpeed();
        }

        Time = new Time(Time.Value + CalculateTrainTime(distance));
        double currentDistance = distance;
        while (currentDistance > 0)
        {
            Speed = new Speed(CalculateNormalTrainSpeed());
            double resultDistance = CalculateTrainResultDistance();
            currentDistance -= resultDistance;
            Distance = new Distance(Distance.Value + resultDistance);
        }

        return new SuccessResult.TravelSuccessResultNormalArea();
    }

    public Result MovePowerArea(double power, double distance)
    {
        Acceleration = CalculateTrainAcceleration(power);
        Time = new Time(Time.Value + CalculateTrainTimeInPowerArea(distance));

        if (PowerOn < power)
        {
            return new TrainResult.TheTrainCouldntHandleTheAcceleration();
        }

        double currentDistance = distance;
        while (currentDistance > 0)
        {
            Speed = new Speed(CalculatePowerTrainSpeed());
            if (Speed <= 0)
            {
                return new TrainResult.TheTrainHasNoSpeed();
            }

            double resultDistance = CalculateTrainResultDistance();
            currentDistance -= resultDistance;
            Distance = new Distance(Distance.Value + resultDistance);
        }

        return new SuccessResult.TravelSuccessResultPowerArea();
    }

    public Result MoveStationArea(double distance, double stopSpeed, double stopTime)
    {
        if (Speed > stopSpeed)
        {
            return new AreaResult.TheStationDidNotStopTheTrain();
        }

        Time = new Time(Time.Value + stopTime);
        double currentDistance = distance;
        while (currentDistance > 0)
        {
            Speed = new Speed(CalculateNormalTrainSpeed());
            double resultDistance = CalculateTrainResultDistance();
            currentDistance -= resultDistance;
            Distance = new Distance(Distance.Value + resultDistance);
        }

        return new SuccessResult.TravelSuccessResultStationArea();
    }

    private double CalculateTrainAcceleration(double power)
    {
        double weight = Weight;
        return power / weight;
    }

    private double CalculateTrainTimeInPowerArea(double distance)
    {
        return Math.Sqrt(2 * distance / Math.Abs(Acceleration));
    }

    private double CalculateTrainTime(double distance)
    {
        double speed = Speed;
        return distance / speed;
    }

    private double CalculatePowerTrainSpeed()
    {
        double speed = Speed;
        double acceleration = Acceleration;
        double aim = Aim;
        return speed + (acceleration * aim);
    }

    private double CalculateNormalTrainSpeed()
    {
        double speed = Speed;
        double aim = Aim;
        return speed + (0 * aim);
    }

    private double CalculateTrainResultDistance()
    {
        double speed = Speed;
        double aim = Aim;
        return speed * aim;
    }
}
