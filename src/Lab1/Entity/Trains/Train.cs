namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;

public class Train(
    uint weight,
    long speed,
    float acceleration,
    double time,
    uint powerOn,
    uint aim,
    uint distance)
{
    public uint Weight { get; } = weight;

    public long Speed { get; set; } = speed;

    public float Acceleration { get; set; } = acceleration;

    public double Time { get; set; } = time;

    public uint PowerOn { get; } = powerOn;

    public uint Aim { get; } = aim;

    public long Distance { get; set; } = distance;
}