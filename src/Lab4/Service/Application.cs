using Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Models.Validators;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Other;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Delete;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Disconnect;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.GoToTree;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.ListTree;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Move;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Rename;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service;

public sealed class Application : IDisposable
{
    private SystemEnvironment? _operatingSystem;
    private bool _disposed;

    public void LaunchApp()
    {
        var fileTreeVisualizer = new TreeShow(new Writer(), new TreeSymbols());
        _operatingSystem = new SystemEnvironment(
            new PathValidator(), fileTreeVisualizer);

        var connectCommandParser = new ConnectParser();
        var disconnectCommandParser = new DisconnectParser();
        var fileCopyCommandParser = new CopyParser();
        var fileDeleteCommandParser = new DeleteParser();
        var fileMoveCommandParser = new MoveParser();
        var fileRenameCommandParser = new RenameParser();
        var fileShowCommandParser = new ShowParser();
        var treeGoToCommandParser = new GoToTreeParser();
        var treeListCommandParser = new ListTreeParser();

        disconnectCommandParser.SetNext(fileCopyCommandParser)
            ?.SetNext(fileDeleteCommandParser)
            ?.SetNext(fileMoveCommandParser)
            ?.SetNext(fileRenameCommandParser)
            ?.SetNext(fileShowCommandParser)
            ?.SetNext(treeGoToCommandParser)
            ?.SetNext(treeListCommandParser);

        ICommand? request = null;
        do
        {
            string? command = Console.ReadLine();
            if (command != null) request = connectCommandParser.Parse(command);
            request?.Execute(_operatingSystem);
        }
        while (request is not ICommand);

        do
        {
            string? command = Console.ReadLine();
            if (command != null) request = disconnectCommandParser.Parse(command);
            request?.Execute(_operatingSystem);
        }
        while (request is not DisconnectCommand);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            _operatingSystem?.TerminateConnection();
        }

        _disposed = true;
    }
}
