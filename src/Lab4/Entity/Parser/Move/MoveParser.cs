using Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Alerts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Move;

public class MoveParser : ParserBase
{
    private readonly IEnumerable<ICommandHandlerMove> _handlers;

    public MoveParser()
    {
        _handlers = new List<ICommandHandlerMove>
        {
            new SourcePathHandlerMove(),
            new DestinationPathHandlerMove(),
        };
    }

    public override ICommand? Parse(string command)
    {
        if (string.IsNullOrEmpty(command))
        {
            Writer.Write(new CommandAlert().Message);
            return null;
        }

        if (!command.Contains("file move", StringComparison.Ordinal))
            return base.Parse(command);

        string[] parts = command.Split(' ');
        if (parts.Length < 4 || parts[0] != "file" || parts[1] != "move")
        {
            Writer.Write(new CommandAlert().Message);
            return null;
        }

        var result = new ParsingResultMove();

        foreach (ICommandHandlerMove handler in _handlers)
        {
            if (handler.CanHandle(parts))
                handler.Handle(parts, result);
        }

        ICommand fileRelocateCommand = new MoveCommand(result.SourcePath, result.DestinationPath);
        return fileRelocateCommand;
    }
}