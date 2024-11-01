namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;

public abstract record Result
{
    public sealed record TravelSuccessResult() : Result;
}