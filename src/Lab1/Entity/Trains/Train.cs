namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;

public record Train(
    uint Weight,
    uint Speed,
    float Acceleration,
    float Time,
    uint PowerOn,
    uint Aim,
    uint Distance);
