using Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.FileSystem;

public class LocalSystem : ISystem
{
    private readonly SystemEnvironment? _operatingSystem;
    private string? _absolutePath;

    public LocalSystem(SystemEnvironment? operatingSystem)
    {
        _operatingSystem = operatingSystem;
    }

    public void EstablishConnection(string address)
    {
        if (_operatingSystem != null && !_operatingSystem.PathValidator.IsAbsolutePath(address))
        {
            Console.WriteLine("You can't connect using this path");
            return;
        }

        if (_absolutePath != null) Path.GetFullPath(address);
        _absolutePath = address;
    }

    public void TerminateConnection()
    {
        _absolutePath = null;
    }

    public void NavigateToDirectory(string path)
    {
        if (_operatingSystem == null) return;
        if (_absolutePath == null) return;
        string fullPath = GenerateAbsolutePath(_absolutePath, path);
        if (!Path.Exists(fullPath)) return;
        _operatingSystem.TreeShow.SetStartDirectory(fullPath);
    }

    public void DisplayTreeStructure(int depth)
    {
        _operatingSystem?.TreeShow.Display(depth);
    }

    public void DisplayFileContent(string path)
    {
        if (_absolutePath == null) return;
        if (_operatingSystem == null) return;
        if (!_operatingSystem.PathValidator.IsAbsolutePath(path))
            path = GenerateAbsolutePath(_absolutePath, path);

        _operatingSystem.TextShow?.DisplayContent(path);
    }

    public void RelocateFile(string sourcePath, string destinationPath)
    {
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("File at the source path not found");
            return;
        }

        if (File.Exists(destinationPath))
            File.Delete(destinationPath);

        string fullPath = " ";
        if (_absolutePath != null)
            fullPath = GenerateAbsolutePath(_absolutePath, destinationPath);

        File.Move(sourcePath, fullPath);
    }

    public void DuplicateFile(string sourcePath, string destinationPath)
    {
        if (_absolutePath == null || sourcePath == null) return;
        if (_operatingSystem == null) return;
        string oldPath = GenerateAbsolutePath(_absolutePath, sourcePath);
        string newPath = GenerateAbsolutePath(_absolutePath, destinationPath);
        try
        {
            File.Copy(oldPath, newPath);
        }
        catch (IOException copyError)
        {
            Console.WriteLine(copyError.Message);
        }
    }

    public void RemoveFile(string path)
    {
        if (_absolutePath == null || path == null) return;
        if (_operatingSystem == null) return;
        string fullPath = GenerateAbsolutePath(_absolutePath, path);
        File.Delete(fullPath);
    }

    public void ChangeFileName(string path, string newName)
    {
        if (string.IsNullOrEmpty(_absolutePath) || string.IsNullOrEmpty(path))
        {
            Console.WriteLine("Path or absolute path cannot be null or empty.");
            return;
        }

        if (_operatingSystem == null)
        {
            Console.WriteLine("Operating system is not initialized.");
            return;
        }

        string oldPath = GenerateAbsolutePath(_absolutePath, path);
        string newPath = GenerateAbsolutePath(_absolutePath, newName);

        if (!File.Exists(oldPath))
        {
            Console.WriteLine($"File at {oldPath} does not exist.");
            return;
        }

        if (File.Exists(newPath))
        {
            Console.WriteLine("File with this name already exists");
            return;
        }

        try
        {
            File.Move(oldPath, newPath);
            Console.WriteLine($"File renamed from {oldPath} to {newPath}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Access denied: {ex.Message}");
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine($"Directory not found: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"IO error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while renaming the file: {ex.Message}");
        }
    }

    public string GenerateAbsolutePath(string path1, string path2)
    {
        if (string.IsNullOrEmpty(path1) || string.IsNullOrEmpty(path2))
            throw new ArgumentException("Path cannot be null or empty.");

        if (Path.IsPathRooted(path2))
            return path2;

        if (path2[0] != '.')
            path2 = "." + Path.DirectorySeparatorChar + path2;

        return Path.GetFullPath(Path.Combine(path1, path2));
    }
}
