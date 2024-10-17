namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;

public class Train(
    double weight,
    double speed,
    double acceleration,
    double time,
    double powerOn,
    double aim,
    double distance)
{
    public double Weight { get; } = weight;

    public double Speed { get; set; } = speed;

    public double Acceleration { get; set; } = acceleration;

    public double Time { get; set; } = time;

    public double PowerOn { get; } = powerOn;

    public double Aim { get; } = aim;

    public double Distance { get; set; } = distance;
}