using Itmo.ObjectOrientedProgramming.Lab1;
using Itmo.ObjectOrientedProgramming.Lab1.Areas;
using Itmo.ObjectOrientedProgramming.Lab1.Model;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab1.Tests;

public class Tests
{
    [Fact]
    public void Test1()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300));
        collectionOfAreas.Add(new NormalArea(100));
        var train = new Train(1000, 0, 0, 0, 500);
        Result finish = Service.Drive(train, collectionOfAreas);
        bool result = finish is Result.Success;
        Assert.True(result);
    }
}