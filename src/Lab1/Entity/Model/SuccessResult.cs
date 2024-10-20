using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;

public abstract record SuccessResult : Result
{
    public sealed record TravelSuccessResultNormalArea(Train Train) : Result;

    public sealed record TravelSuccessResultPowerArea(Train Train) : Result;

    public sealed record TravelSuccessResultStationArea(Train Train) : Result;
}