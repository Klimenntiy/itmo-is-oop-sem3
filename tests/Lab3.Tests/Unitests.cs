using FluentAssertions;
using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Decorators;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Proxys;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Recipients;
using NSubstitute;
using Xunit;

namespace Lab3.Tests;

public class UniTests
{
    [Fact]
    public void MessageIsUnreadWhenReceived()
    {
        var message = new Message("meow", "this is a test", 1, 0);
        var user = new User("german", "meow");
        var addressUser = new AddressUser(user);
        var topic = new Topic("german", addressUser);

        topic.SendMessage(message);

        Assert.False(User.CheckStatus(user.UserMessages.FirstOrDefault()));
    }

    [Fact]
    public void MessageDoesNotReachUserWithImportanceFilter()
    {
        var message = new Message("bruh", "yo", 1, 0);
        var user = new User("german", "meow");
        User moqUser = Substitute.For<User>(user);
        var addressUser = new AddressUser(moqUser);
        var proxyAddress = new Proxy(addressUser, 2);
        var topic = new Topic("german", proxyAddress);

        FinalResult res = topic.SendMessage(message);

        moqUser.DidNotReceive().AcceptMessage(message);
        Assert.True(res == new FinalResult.Unimportant());
    }

    [Fact]
    public void MessageStatusChangesToRead()
    {
        var message = new Message("bruh", "yo", 1, 0);
        var user = new User("german", "meow");
        var addressUser = new AddressUser(user);
        var topic = new Topic("german", addressUser);

        topic.SendMessage(message);
        user.MessageIsRead(0);

        Assert.True(User.CheckStatus(user.UserMessages.FirstOrDefault()));
    }

    [Fact]
    public void CannotMarkAlreadyReadMessageAsRead()
    {
        var message = new Message("obeme", "yo", 1, 0);
        var user = new User("german", "meow");
        var addressUser = new AddressUser(user);
        var topic = new Topic("german", addressUser);

        topic.SendMessage(message);

        FinalResult exception = user.MessageIsRead(0);

        Assert.True(exception == new FinalResult.TheMessageHasAlreadyBeenRead());
    }

    [Fact]
    public void LogIsWrittenWhenMessageArrives()
    {
        var message = new Message("meow", "yo", 1, 0);
        var user = new User("german", "meow");

        IAddress mockAddressUser = Substitute.For<IAddress>();
        var logDecorator = new Decorator(mockAddressUser);

        var topic = new Topic("german", logDecorator);

        FinalResult res = topic.SendMessage(message);

        logDecorator.Log.Should().Contain(message);
        mockAddressUser.Received().AcceptMessage(message);
        Assert.True(res == new FinalResult.Success());
    }

    [Fact]
    public void MessengerProducesExpectedValueWhenMessageSent()
    {
        var message = new Message("meow", "yo", 1, 0);
        var messenger = new Messenger("german", "meow");
        Messenger moqMessenger = Substitute.For<Messenger>(messenger);
        var addressMessenger = new AddressMessanger(moqMessenger);
        var topic = new Topic("german", addressMessenger);

        FinalResult res = topic.SendMessage(message);

        moqMessenger.Received().Print();
        Assert.True(res == new FinalResult.Success());
    }

    [Fact]
    public void MessageSentWithLowImportanceIsReceivedOnce()
    {
        var message = new Message("meow", "yo", 1, 0);
        var user1 = new User("german", "meow");
        var user2 = new User("ivan", "hello");

        User moqUser1 = Substitute.For<User>(user1);
        User moqUser2 = Substitute.For<User>(user2);

        var addressUser1 = new AddressUser(moqUser1);
        var addressUser2 = new AddressUser(moqUser2);

        var proxyAddress1 = new Proxy(addressUser1, 2);
        var topic = new Topic("german", proxyAddress1);
        var topic2 = new Topic("german", addressUser2);

        FinalResult res = topic.SendMessage(message);
        Assert.True(res == new FinalResult.Unimportant());
        moqUser1.DidNotReceive().AcceptMessage(message);
        FinalResult res2 = topic2.SendMessage(message);
        Assert.True(res2 == new FinalResult.Success());
        moqUser2.Received(1).AcceptMessage(message);
    }
}