using Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Alerts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.GoToTree;

public class GoToTreeParser : ParserBase
{
    private readonly IEnumerable<ICommandHandlerGoToTree> _handlers;

    public GoToTreeParser()
    {
        _handlers = new List<ICommandHandlerGoToTree>
        {
            new PathHandlerGoToTree(),
        };
    }

    public override ICommand? Parse(string command)
    {
        if (string.IsNullOrEmpty(command))
        {
            Writer.Write(new CommandAlert().Message);
            return null;
        }

        if (!command.Contains("tree goto", StringComparison.Ordinal))
            return base.Parse(command);

        string[] parts = command.Split(' ');
        if (parts.Length < 3 || parts[0] != "tree" || parts[1] != "goto")
        {
            Writer.Write(new CommandAlert().Message);
            return null;
        }

        var result = new ParsingResultGoToTree();

        foreach (ICommandHandlerGoToTree handler in _handlers)
        {
            if (handler.CanHandle(parts))
                handler.Handle(parts, result);
        }

        ICommand navigateToTreeCommand = new GoToTreeCommand(result.Path);
        return navigateToTreeCommand;
    }
}