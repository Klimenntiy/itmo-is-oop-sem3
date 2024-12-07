namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

public static class FileSystemInfoExtensions
{
    public static void Accept(this FileSystemInfo fsi, IVisitor visitor)
    {
        if (fsi is DirectoryInfo di)
        {
            visitor.Visit(di);
        }
        else if (fsi is FileInfo fi)
        {
            visitor.Visit(fi);
        }
    }
}