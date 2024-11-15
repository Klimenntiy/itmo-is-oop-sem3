namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;

public abstract record FinalResult
{
    public sealed record TheMessageHasAlreadyBeenRead : FinalResult;

    public sealed record Success : FinalResult;

    public sealed record Unimportant : FinalResult;

    public sealed record NoFilters : FinalResult;
}