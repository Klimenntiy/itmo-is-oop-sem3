using Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Alerts;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser;

public class ShowParser : ParserBase
{
    private readonly IEnumerable<ICommandHandler> _handlers;

    public ShowParser()
    {
        _handlers = new List<ICommandHandler>
        {
            new PathHandlerShow(),
            new ModeHandlerShow(),
        };
    }

    public override ICommand? Parse(string command)
    {
        if (string.IsNullOrEmpty(command))
        {
            Writer.Write(new CommandAlert().Message);
            return null;
        }

        if (!command.Contains("file show", StringComparison.Ordinal))
            return base.Parse(command);

        string[] parts = command.Split(' ');
        if (parts.Length < 3 || parts[0] != "file" || parts[1] != "show")
        {
            Writer.Write(new CommandAlert().Message);
            return null;
        }

        var result = new ParsingResultShow();

        foreach (ICommandHandler handler in _handlers)
        {
            if (handler.CanHandle(parts))
                handler.Handle(parts, result);
        }

        if (result.Mode != "console") return base.Parse(command);
        ICommand displayFileCommand = new ShowCommand(result.Path);
        return displayFileCommand;
    }
}