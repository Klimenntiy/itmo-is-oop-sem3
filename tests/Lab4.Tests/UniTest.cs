using Itmo.ObjectOrientedProgramming.Lab4.Entity.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Delete;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Disconnect;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.GoToTree;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.ListTree;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Move;
using Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Rename;
using Xunit;

namespace Lab4.Tests;

public class UniTest
{
    [Fact]
    public void ParseConsoleTest()
    {
        var connectCommandParser = new ConnectParser();
        var disconnectCommandParser = new DisconnectParser();
        var fileCopyCommandParser = new CopyParser();
        var fileDeleteCommandParser = new DeleteParser();
        var fileMoveCommandParser = new MoveParser();
        var fileRenameCommandParser = new RenameParser();
        var fileShowCommandParser = new ShowParser();
        var treeGoToCommandParser = new GoToTreeParser();
        var treeListCommandParser = new ListTreeParser();

        connectCommandParser.SetNext(disconnectCommandParser)
            ?.SetNext(fileCopyCommandParser)
            ?.SetNext(fileDeleteCommandParser)
            ?.SetNext(fileMoveCommandParser)
            ?.SetNext(fileRenameCommandParser)
            ?.SetNext(fileShowCommandParser)
            ?.SetNext(treeGoToCommandParser)
            ?.SetNext(treeListCommandParser);

        string command = "connect /Users/ -m local";
        ICommand? request = connectCommandParser.Parse(command);
        bool result = request is ConnectCommand;
        Assert.True(result);
    }
}