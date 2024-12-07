using Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Alerts;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Copy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser;

public class CopyParser : ParserBase
{
    private readonly IEnumerable<ICommandHandlerCopy> _handlers;

    public CopyParser()
    {
        _handlers = new List<ICommandHandlerCopy>
        {
            new SourcePathHandlerCopy(),
            new DestinationPathHandlerCopy(),
        };
    }

    public override ICommand? Parse(string command)
    {
        if (string.IsNullOrEmpty(command))
        {
            Writer.Write(new CommandAlert().Message);
            return null;
        }

        if (!command.Contains("file copy", StringComparison.Ordinal))
            return base.Parse(command);

        string[] parts = command.Split(' ');
        if (parts.Length < 4 || parts[0] != "file" || parts[1] != "copy")
        {
            Writer.Write(new CommandAlert().Message);
            return null;
        }

        var result = new ParsingResultCopy();

        foreach (ICommandHandlerCopy handler in _handlers)
        {
            if (handler.CanHandle(parts))
                handler.Handle(parts, result);
        }

        ICommand fileDuplicateCommand = new Command.CopyCommand(result.SourcePath, result.DestinationPath);
        return fileDuplicateCommand;
    }
}