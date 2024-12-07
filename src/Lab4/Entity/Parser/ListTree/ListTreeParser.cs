using Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Alerts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.ListTree;

public class ListTreeParser : ParserBase
{
    private readonly IEnumerable<ICommandHandlerListTree> _handlers;

    public ListTreeParser()
    {
        _handlers = new List<ICommandHandlerListTree>
            {
                new PathHandlerListTree(),
            };
    }

    public override ICommand? Parse(string command)
    {
        if (string.IsNullOrEmpty(command))
        {
            Writer.Write(new CommandAlert().Message);
            return null;
        }

        if (!command.Contains("tree list", StringComparison.Ordinal))
            return base.Parse(command);

        string[] parts = command.Split(' ');
        if (parts.Length < 2 || parts[0] != "tree" || parts[1] != "list")
        {
            Writer.Write(new CommandAlert().Message);
            return null;
        }

        var result = new ParsingResultListTree();

        foreach (ICommandHandlerListTree handler in _handlers)
        {
            if (handler.CanHandle(parts))
                handler.Handle(parts, result);
        }

        ICommand displayTreeCommand = new ListTreeCommand(result.Depth);
        return displayTreeCommand;
    }
}
