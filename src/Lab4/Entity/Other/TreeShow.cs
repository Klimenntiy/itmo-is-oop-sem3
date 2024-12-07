using Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

public class TreeShow
{
    private readonly IWriter _writer;
    private readonly TreeSymbols _symbols;
    private string? _startPath;

    public TreeShow(IWriter writer, TreeSymbols symbols)
    {
        _writer = writer;
        _symbols = symbols;
    }

    public void Display(int maxDepth = 1)
    {
        if (_startPath == null) return;
        var visitor = new TreeShowVisitor(_writer, _symbols, maxDepth);
        var di = new DirectoryInfo(_startPath);
        di.Accept(visitor);
    }

    public void SetStartDirectory(string path)
    {
        _startPath = path;
    }
}