using Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

public class TreeShowVisitor : IVisitor
{
    private readonly IWriter _writer;
    private readonly TreeSymbols _symbols;
    private readonly int _maxDepth;
    private int _currentDepth;
    private string _prefix;

    public TreeShowVisitor(IWriter writer, TreeSymbols symbols, int maxDepth)
    {
        _writer = writer;
        _symbols = symbols;
        _maxDepth = maxDepth;
        _currentDepth = 0;
        _prefix = string.Empty;
    }

    public void Visit(DirectoryInfo directoryInfo)
    {
        if (_currentDepth >= _maxDepth) return;

        _writer.Write(_prefix + _symbols.IndentationSymbol);
        _writer.Write(_symbols.DirectoryBranchSymbol + directoryInfo.Name);
        _writer.WriteNewLine();

        var fsItems = directoryInfo.GetFileSystemInfos().OrderBy(f => f.Name, StringComparer.Ordinal).ToList();

        foreach (FileSystemInfo fsItem in fsItems.Take(fsItems.Count - 1))
        {
            fsItem.Accept(this);
        }

        if (fsItems.Count > 0)
        {
            FileSystemInfo lastFsItem = fsItems.Last();
            _prefix += _symbols.DirectoryBranchSymbol;
            lastFsItem.Accept(this);
            _prefix = _prefix.Substring(0, _prefix.Length - 1);
        }

        _currentDepth++;
    }

    public void Visit(FileInfo fileInfo)
    {
        _writer.Write(_prefix + _symbols.IndentationSymbol);
        _writer.Write(_symbols.FileBranchSymbol + fileInfo.Name);
        _writer.WriteNewLine();
    }
}