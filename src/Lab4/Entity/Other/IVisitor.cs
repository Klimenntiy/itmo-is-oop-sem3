namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

public interface IVisitor
{
    void Visit(DirectoryInfo directoryInfo);

    void Visit(FileInfo fileInfo);
}