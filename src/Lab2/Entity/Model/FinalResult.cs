namespace Itmo.ObjectOrientedProgramming.Lab2.Entity.Model;

public abstract record FinalResult
{
    public sealed record ItsNotTheAuthorWhoChangesTheEssence() : FinalResult;

    public sealed record SubjectScoresDoNotEqualAHundred() : FinalResult;

    public sealed record Success() : FinalResult;
}