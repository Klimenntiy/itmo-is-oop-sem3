namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Validators;

public class PathValidator : IPathValidator
{
    public bool IsAbsolutePath(string path)
    {
        return Path.IsPathRooted(path);
    }
}