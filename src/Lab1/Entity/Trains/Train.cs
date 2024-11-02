using Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.AimValue;
using static Itmo.ObjectOrientedProgramming.Lab1.ValueObjects.CreateValueObjects;
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
        Weight = CreateWeight(weightValue);
        Speed = CreateSpeed(speedValue);
        Acceleration = acceleration;
        Time = CreateTime(timeValue);
        PowerOn = CreatePowerOn(powerOnValue);
        Aim = CreateAim(aimValue);
        Distance = CreateDistance(distanceValue);
    }

    public FinalResult MoveNormalArea(double distance)
    {
        return Move(distance, 0);
    }

    public FinalResult MovePowerArea(double power, double distance)
    {
        Acceleration = CalculateTrainAcceleration(power);
        if (PowerOn < power)
        {
            return new TrainResult.TheTrainCouldntHandleTheAcceleration();
        }

        return Move(distance, power);
    }

    public FinalResult MoveStationArea(double distance, double stopSpeed, double stopTime)
    {
        if (Speed > stopSpeed)
        {
            return new AreaResult.TheStationDidNotStopTheTrain();
        }

        Time = new Time(Time + stopTime);
        return Move(distance, 0);
    }

    private FinalResult Move(double distance, double power)
    {
        Time = new Time(Time + CalculateTrainTime(distance));

        double currentDistance = distance;
        while (currentDistance > 0)
        {
            if (power > 0)
            {
                Speed = new Speed(CalculatePowerTrainSpeed());
            }
            else
            {
                Speed = new Speed(CalculateNormalTrainSpeed());
            }

            if (Speed <= 0)
            {
                return new TrainResult.TheTrainHasNoSpeed();
            }

            double resultDistance = CalculateTrainResultDistance();
            currentDistance -= resultDistance;
            Distance = new Distance(Distance + resultDistance);
        }

        return new FinalResult.TravelSuccessResult();
    }

    private double CalculateTrainAcceleration(double power)
    {
        double weight = Weight;
        return power / weight;
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
