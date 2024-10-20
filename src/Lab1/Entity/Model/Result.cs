using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;

public abstract record Result
{
    public sealed record TravelSuccessResult(Train Train) : Result;

    public sealed record TheTrainCouldntHandleTheAcceleration() : Result;

    public sealed record TheTrainHasNoSpeed() : Result;

    public sealed record TheStationDidNotStopTheTrain() : Result;

    public sealed record MaximumPermissibleSpeed() : Result;
}