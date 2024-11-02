namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;

public record FinalResult
{
    public sealed record TravelSuccessResult() : FinalResult;

    public sealed record TravelFailureResult() : FinalResult;
}