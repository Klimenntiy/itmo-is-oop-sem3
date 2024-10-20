namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;

public abstract record TrainResult : Result
{
    public sealed record TheTrainCouldntHandleTheAcceleration() : Result;

    public sealed record TheTrainHasNoSpeed() : Result;
}