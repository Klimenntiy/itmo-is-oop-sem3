namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

public class Writer : IWriter
{
    public void WriteNewLine()
    {
        Write(Environment.NewLine);
    }

    public void Write(string text)
    {
        Console.Write(text);
    }
}