namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;

public record AreaResult : FinalResult
{
    public sealed record MaximumPermissibleSpeed() : FinalResult;

    public sealed record TheStationDidNotStopTheTrain() : FinalResult;
}