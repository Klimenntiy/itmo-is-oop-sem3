using Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Alerts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Rename;

public class RenameParser : ParserBase
{
    private readonly IEnumerable<ICommandHandlerRename> _handlers;

    public RenameParser()
    {
        _handlers = new List<ICommandHandlerRename>
        {
            new PathHandlerRename(),
            new NewNameHandler(),
        };
    }

    public override ICommand? Parse(string command)
    {
        if (string.IsNullOrEmpty(command))
        {
            Writer.Write(new CommandAlert().Message);
            return null;
        }

        if (!command.Contains("file rename", StringComparison.Ordinal))
            return base.Parse(command);

        string[] parts = command.Split(' ');
        if (parts.Length < 4 || parts[0] != "file" || parts[1] != "rename")
        {
            Writer.Write(new CommandAlert().Message);
            return null;
        }

        var result = new ParsingResultRename();

        foreach (ICommandHandlerRename handler in _handlers)
        {
            if (handler.CanHandle(parts))
                handler.Handle(parts, result);
        }

        ICommand changeFileNameCommand = new RenameCommand(result.Path, result.NewName);
        return changeFileNameCommand;
    }
}