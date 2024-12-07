using Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Alerts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Disconnect;

public class DisconnectParser : ParserBase
{
    public override ICommand? Parse(string command)
    {
        if (string.IsNullOrEmpty(command))
        {
            Writer.Write(new CommandAlert().Message);
            return null;
        }

        if (!command.Contains("disconnect", StringComparison.Ordinal))
            return base.Parse(command);

        string[] parts = command.Split(' ');
        if (parts.Length > 1 || parts[0] != "disconnect")
        {
            Writer.Write(new CommandAlert().Message);
            return null;
        }

        ICommand terminateConnectionCommand = new DisconnectCommand();
        return terminateConnectionCommand;
    }
}