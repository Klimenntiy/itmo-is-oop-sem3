namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;

public abstract record AreaResult : Result
{
    public sealed record MaximumPermissibleSpeed() : Result;

    public sealed record TheStationDidNotStopTheTrain() : Result;
}