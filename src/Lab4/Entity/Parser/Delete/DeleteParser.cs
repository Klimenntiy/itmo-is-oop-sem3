using Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Alerts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Delete;

public class DeleteParser : ParserBase
{
    private readonly IEnumerable<ICommandHandlerDelete> _handlers;

    public DeleteParser()
    {
        _handlers = new List<ICommandHandlerDelete>
        {
            new PathHandlerDelete(),
        };
    }

    public override ICommand? Parse(string command)
    {
        if (string.IsNullOrEmpty(command))
        {
            Writer.Write(new CommandAlert().Message);
            return null;
        }

        if (!command.Contains("file delete", StringComparison.Ordinal))
            return base.Parse(command);

        string[] parts = command.Split(' ');
        if (parts.Length < 3 || parts[0] != "file" || parts[1] != "delete")
        {
            Writer.Write(new CommandAlert().Message);
            return null;
        }

        var result = new ParsingResultDelete();

        foreach (ICommandHandlerDelete handler in _handlers)
        {
            if (handler.CanHandle(parts))
                handler.Handle(parts, result);
        }

        ICommand fileRemoveCommand = new DeleteCommand(result.Path);
        return fileRemoveCommand;
    }
}