namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;

public class ContentShow
{
    private readonly IWriter _writer;

    public ContentShow(IWriter writer)
    {
        _writer = writer;
    }

    public void DisplayContent(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            _writer.Write("Invalid path provided.");
            return;
        }

        if (!File.Exists(path))
        {
            _writer.Write($"File at path {path} does not exist.");
            return;
        }

        try
        {
            using var sr = new StreamReader(path);
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                _writer.Write(line);
                _writer.WriteNewLine();
            }
        }
        catch (Exception ex)
        {
            _writer.Write($"An error occurred while reading the file: {ex.Message}");
        }
    }
}