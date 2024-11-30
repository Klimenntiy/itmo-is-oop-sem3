using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Addresses;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Filters;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab3.Entity.Recipients;
using NSubstitute;
using Xunit;

namespace Lab3.Tests;

public class UniTests
{
    [Fact]
    public void MessageIsUnreadWhenReceived()
    {
        var messageBuilder = new MessageBuilder();
        messageBuilder.WithHeader("meow");
        messageBuilder.WithBody("this is a message");
        messageBuilder.WithId(0);
        messageBuilder.WithPriority(1);
        Message message = messageBuilder.Build();
        var user = new User("german", "meow");
        var addressUser = new AddressUser(user);
        var topic = new Topic("german", addressUser);

        topic.SendMessage(message);

        Assert.False(User.CheckStatus(user.UserMessages.FirstOrDefault()));
    }

    [Fact]
    public void MessageDoesNotReachUserWithImportanceFilter()
    {
        var messageBuilder = new MessageBuilder();
        messageBuilder.WithHeader("meow");
        messageBuilder.WithBody("this is a message");
        messageBuilder.WithId(0);
        messageBuilder.WithPriority(1);
        Message message = messageBuilder.Build();
        var user = new User("german", "meow");
        User moqUser = Substitute.For<User>(user);
        var addressUser = new AddressUser(moqUser);
        var proxyAddress = new FilterAddress(addressUser, 2);
        var filterAddress = new FilterAddress(addressUser, 2);
        filterAddress.AddFilter(new ImportanceFilter());
        var topic = new Topic("german", proxyAddress);

        FinalResult res = topic.SendMessage(message);

        moqUser.DidNotReceive().AcceptMessage(message);
    }

    [Fact]
    public void MessageStatusChangesToRead()
    {
        var messageBuilder = new MessageBuilder();
        messageBuilder.WithHeader("meow");
        messageBuilder.WithBody("this is a message");
        messageBuilder.WithId(0);
        messageBuilder.WithPriority(1);
        Message message = messageBuilder.Build();
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
        var messageBuilder = new MessageBuilder();
        messageBuilder.WithHeader("meow");
        messageBuilder.WithBody("this is a message");
        messageBuilder.WithId(0);
        messageBuilder.WithPriority(1);
        Message message = messageBuilder.Build();
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
        var messageBuilder = new MessageBuilder();
        messageBuilder.WithHeader("meow");
        messageBuilder.WithBody("this is a message");
        messageBuilder.WithId(0);
        messageBuilder.WithPriority(1);
        Message message = messageBuilder.Build();
        var user = new User("german", "meow");

        var messageLogger = new MessageLogger();
        IAddress mockAddressUser = Substitute.For<IAddress>();
        var logDecorator = new LoggerDecorator(mockAddressUser, messageLogger);

        var topic = new Topic("german", logDecorator);

        FinalResult res = topic.SendMessage(message);

        mockAddressUser.Received().AcceptMessage(message);
    }

    [Fact]
    public void MessengerProducesExpectedValueWhenMessageSent()
    {
        var messageBuilder = new MessageBuilder();
        messageBuilder.WithHeader("meow");
        messageBuilder.WithBody("this is a message");
        messageBuilder.WithId(0);
        messageBuilder.WithPriority(1);
        Message message = messageBuilder.Build();

        Messenger moqMessenger = Substitute.For<Messenger>("german", "meow");
        var addressMessenger = new AddressMessenger(moqMessenger);
        var topic = new Topic("german", addressMessenger);

        FinalResult res = topic.SendMessage(message);

        moqMessenger.Received().Print(message.Body);
        Assert.True(res.Equals(new FinalResult.Success()), "Expected success result was not returned.");
    }

    [Fact]
    public void MessageSentWithLowImportanceIsReceivedOnce()
    {
        var messageBuilder = new MessageBuilder();
        messageBuilder.WithHeader("meow");
        messageBuilder.WithBody("this is a message");
        messageBuilder.WithId(0);
        messageBuilder.WithPriority(1);
        Message message = messageBuilder.Build();

        var user1 = new User("german", "meow");
        var user2 = new User("ivan", "hello");

        User moqUser1 = Substitute.For<User>(user1);
        User moqUser2 = Substitute.For<User>(user2);

        var addressUser1 = new AddressUser(moqUser1);
        var addressUser2 = new AddressUser(moqUser2);

        var filterAddress = new FilterAddress(addressUser1, 2);
        filterAddress.AddFilter(new ImportanceFilter());

        var topic = new Topic("german", filterAddress);
        var topic2 = new Topic("german", addressUser2);

        FinalResult res = topic.SendMessage(message);
        moqUser1.DidNotReceive().AcceptMessage(message);

        FinalResult res2 = topic2.SendMessage(message);
        moqUser2.Received(1).AcceptMessage(message);
    }
}