namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.ListTree;

public class ParsingResultListTree
{
    public int Depth { get; private set; }

    public ParsingResultListTree()
    {
        Depth = 1;
    }

    public void SetDepth(int depth)
    {
        Depth = depth;
    }
}