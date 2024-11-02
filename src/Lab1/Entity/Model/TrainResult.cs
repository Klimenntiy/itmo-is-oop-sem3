namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;

public record TrainResult : FinalResult
{
    public sealed record TheTrainCouldntHandleTheAcceleration() : FinalResult;

    public sealed record TheTrainHasNoSpeed() : FinalResult;
}