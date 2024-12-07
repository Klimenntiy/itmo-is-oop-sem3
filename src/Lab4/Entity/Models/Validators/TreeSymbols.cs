namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Validators;

public class TreeSymbols
{
    public TreeSymbols(
        string fileIcon = "▪",
        string directoryIcon = "\ud83d\udcc2",
        string lastBranchSymbol = "└── ",
        string fileBranchSymbol = "├── ",
        string directoryBranchSymbol = "│   ",
        string indentationSymbol = "    ")
    {
        FileIcon = fileIcon;
        DirectoryIcon = directoryIcon;
        LastBranchSymbol = lastBranchSymbol;
        FileBranchSymbol = fileBranchSymbol;
        DirectoryBranchSymbol = directoryBranchSymbol;
        IndentationSymbol = indentationSymbol;
    }

    public string FileIcon { get; private set; }

    public string DirectoryIcon { get; private set; }

    public string LastBranchSymbol { get; private set; }

    public string FileBranchSymbol { get; private set; }

    public string DirectoryBranchSymbol { get; private set; }

    public string IndentationSymbol { get; private set; }
}