namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.FileSystem;

public interface ISystem
{
    void EstablishConnection(string address);

    void TerminateConnection();

    void NavigateToDirectory(string path);

    void DisplayTreeStructure(int depth);

    void DisplayFileContent(string path);

    void RelocateFile(string sourcePath, string destinationPath);

    void DuplicateFile(string sourcePath, string destinationPath);

    void RemoveFile(string path);

    void ChangeFileName(string path, string newName);

    string GenerateAbsolutePath(string path1, string path2);
}