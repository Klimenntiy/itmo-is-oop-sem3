using Itmo.ObjectOrientedProgramming.Lab4.Entity.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

public class SystemEnvironment
{
    private ISystem? _fileSystem;

    public SystemEnvironment(IPathValidator pathValidator, TreeShow treeShow)
    {
        PathValidator = pathValidator;
        TreeShow = treeShow;
    }

    public ContentShow? TextShow { get; private set; }

    public TreeShow TreeShow { get; }

    public IPathValidator PathValidator { get; }

    public void SwitchToFileSystem(ISystem? fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void SwitchToTextShow(ContentShow show)
    {
        TextShow = show;
    }

    public void EstablishConnection(string address)
    {
        _fileSystem?.EstablishConnection(address);
    }

    public void TerminateConnection()
    {
        _fileSystem?.TerminateConnection();
    }

    public void NavigateToDirectory(string path)
    {
        _fileSystem?.NavigateToDirectory(path);
    }

    public void DisplayTreeStructure(int depth)
    {
        _fileSystem?.DisplayTreeStructure(depth);
    }

    public void DisplayFileContent(string path)
    {
        _fileSystem?.DisplayFileContent(path);
    }

    public void RelocateFile(string sourcePath, string destinationPath)
    {
        _fileSystem?.RelocateFile(sourcePath, destinationPath);
    }

    public void DuplicateFile(string sourcePath, string destinationPath)
    {
        _fileSystem?.DuplicateFile(sourcePath, destinationPath);
    }

    public void RemoveFile(string path)
    {
        _fileSystem?.RemoveFile(path);
    }

    public void ChangeFileName(string path, string newName)
    {
        _fileSystem?.ChangeFileName(path, newName);
    }
}