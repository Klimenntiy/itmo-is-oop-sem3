using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;

public abstract record Result
{
    public sealed record TravelSuccessResult(Train Train) : Result;
}