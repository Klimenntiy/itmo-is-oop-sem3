using Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Alerts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser;

public class ConnectParser : ParserBase
{
    public override ICommand? Parse(string command)
    {
        if (string.IsNullOrEmpty(command))
        {
            Console.WriteLine(new ConnectionAlert().Message);
            return null;
        }

        if (!command.Contains("connect", StringComparison.Ordinal))
        {
            Writer.Write(new ConnectionAlert().Message);
            return null;
        }

        string[] parts = command.Split(' ');
        if (parts.Length < 4 || parts[0] != "connect" || parts[2] != "-m")
        {
            Writer.Write(new ConnectionAlert().Message);
            return null;
        }

        string address = parts[1];
        string? mode = parts[3];

        if (mode != "local") return base.Parse(command);

        var connectCommand = new Command.ConnectCommand(address);
        return connectCommand;
    }
}