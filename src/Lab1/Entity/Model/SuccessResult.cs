namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;

public abstract record SuccessResult : Result
{
    public sealed record TravelSuccessResultNormalArea() : Result;

    public sealed record TravelSuccessResultPowerArea() : Result;

    public sealed record TravelSuccessResultStationArea() : Result;
}