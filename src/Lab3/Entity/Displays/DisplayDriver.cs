using Crayon;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity.Displays;

public class DisplayDriver : IDisplay
{
    private Color _color = Color.Empty;

    public void SetColor(Color color)
    {
        _color = color;
    }

    public void Show(Message? message)
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));

        if (_color.IsEmpty)
        {
            throw new InvalidOperationException("The color is not set. Please set the color before displaying the message.");
        }

        string coloredText = Output.Rgb(_color.R, _color.G, _color.B).Text(message.Body);
        Console.WriteLine(coloredText);
    }
}