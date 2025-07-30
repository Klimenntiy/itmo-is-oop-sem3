using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Displays;

public class Display
{
    private readonly DisplayDriver _displayDriver;

    public string CurrentMessage { get; private set; }

    public Display(DisplayDriver displayDriver, string currentMessage)
    {
        _displayDriver = displayDriver;
        CurrentMessage = currentMessage;
    }

    public void ShowText(Color color)
    {
        if (_displayDriver.Message == null) return;
        Console.Clear();
        _displayDriver.SetColor(color);
        Console.WriteLine($"(Display){_displayDriver.Message}");
    }

    public void GetText(string text)
    {
        _displayDriver.SetText(text);
    }

    public void AcceptMessage(string message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        CurrentMessage = message;
    }
}