using Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Service;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab1.Tests;

public class UniTests
{
    [Fact]
    public void CheckForPermissibleRouteSpeedWithPassingOf()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300));
        collectionOfAreas.Add(new NormalArea(100));

        var train = new Train(1000, 0, 0, 0, 500, 5, 0);

        Result finish = Travel.Drive(train, collectionOfAreas, 10);

        bool result = finish is Result.Success;
        Assert.True(result);
        var res = (Result.Success)finish;
        double expected = 41.819888461721021;
        Assert.Equal(res.Result, expected);
    }

    [Fact]
    public void CheckingThePermissibleSpeedOfAnOverspeedRoute()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300));
        collectionOfAreas.Add(new NormalArea(100));

        var train = new Train(1000, 0, 0, 0, 500, 5, 0);

        Result finish = Travel.Drive(train, collectionOfAreas, 1);

        bool result = finish is Result.MaximumPermissibleSpeed;
        Assert.True(result);
    }

    [Fact]
    public void CheckingThePermissibleSpeedOnTheRouteAndStationWithPassingThe()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new StationArea(15, 10, 30));

        var train = new Train(1000, 0, 0, 0, 500, 5, 0);

        Result finish = Travel.Drive(train, collectionOfAreas, 10);

        bool result = finish is Result.Success;
        Assert.True(result);
        var res = (Result.Success)finish;
        double expected = 71.819888461721021;
        Assert.Equal(res.Result, expected);
    }

    [Fact]
    public void CheckOfThePermissibleSpeedOfPassingTheStationWithExcessiveSpeed()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new StationArea(15, 5, 30));

        var train = new Train(1000, 0, 0, 0, 500, 5, 0);

        Result finish = Travel.Drive(train, collectionOfAreas, 10);

        bool result = finish is Result.TheStationDidNotStopTheTrain;
        Assert.True(result);
    }

    [Fact]
    public void AccelerationToTheAllowableSpeedOfTheRouteButNotTheStation()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new StationArea(15, 10, 30));

        var train = new Train(1000, 0, 0, 0, 500, 5, 0);

        Result finish = Travel.Drive(train, collectionOfAreas, 5);

        bool result = finish is Result.MaximumPermissibleSpeed;
        Assert.True(result);
    }

    [Fact]
    public void SpeedReductionCheckForStationAndRoute()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 500));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new PowerArea(100, -130));
        collectionOfAreas.Add(new StationArea(15, 10, 30));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new PowerArea(100, 500));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new PowerArea(100, -400));

        var train = new Train(1000, 0, 0, 0, 500, 5, 0);

        Result finish = Travel.Drive(train, collectionOfAreas, 100);

        bool result = finish is Result.Success;
        Assert.True(result);
        var res = (Result.Success)finish;
        double expected = 178.58390735538438;
        Assert.Equal(res.Result, expected);
    }

    [Fact]
    public void TheresNoAcceleration()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new NormalArea(100));

        var train = new Train(1000, 0, 0, 0, 500, 5, 0);

        Result finish = Travel.Drive(train, collectionOfAreas, 6);

        bool result = finish is Result.TheTrainHasNoSpeed;
        Assert.True(result);
    }

    [Fact]
    public void TheTrainCouldntWithstandTheForceApplied()
    {
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 1000));
        collectionOfAreas.Add(new PowerArea(100, -2000));

        var train = new Train(1000, 0, 0, 0, 500, 5, 0);

        Result finish = Travel.Drive(train, collectionOfAreas, 6);

        bool result = finish is Result.TheTrainCouldntHandleTheAcceleration;
        Assert.True(result);
    }
}
