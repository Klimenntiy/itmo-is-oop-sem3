using Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Service;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab1.Tests;

public class UniTests
{
    [Fact]
    public void CheckForPermissibleRouteSpeedWithPassingOf()
    {
        var train = new Train(1000, 0, 0, 0, 500, 5, 0);
        var collectionOfAreas = new List<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300));
        collectionOfAreas.Add(new NormalArea(100));
        var travel = new Travel(collectionOfAreas);
        FinalResult finish = travel.Drive(train, 10);
        bool trainResult = finish is FinalResult.TravelSuccessResult;
        Assert.True(trainResult);
    }

    [Fact]
    public void CheckingThePermissibleSpeedOfAnOverspeedRoute()
    {
        var train = new Train(1000, 0, 0, 0, 500, 5, 0);
        var collectionOfAreas = new List<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300));
        collectionOfAreas.Add(new NormalArea(100));
        var travel = new Travel(collectionOfAreas);
        FinalResult finish = travel.Drive(train, 1);
        bool trainResult = finish is AreaResult.MaximumPermissibleSpeed;
        Assert.True(trainResult);
    }

    [Fact]
    public void CheckingThePermissibleSpeedOnTheRouteAndStationWithPassingThe()
    {
        var train = new Train(1000, 0, 0, 0, 500, 5, 0);
        var collectionOfAreas = new List<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new StationArea(15, 10, 30));
        var travel = new Travel(collectionOfAreas);
        FinalResult finish = travel.Drive(train, 10);
        bool trainResult = finish is FinalResult.TravelSuccessResult;
        Assert.True(trainResult);
    }

    [Fact]
    public void CheckOfThePermissibleSpeedOfPassingTheStationWithExcessiveSpeed()
    {
        var train = new Train(1000, 0, 0, 0, 500, 5, 0);
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new StationArea(15, 5, 30));
        var travel = new Travel(collectionOfAreas);
        FinalResult finish = travel.Drive(train, 10);
        bool trainResult = finish is AreaResult.TheStationDidNotStopTheTrain;
        Assert.True(trainResult);
    }

    [Fact]
    public void AccelerationToTheAllowableSpeedOfTheRouteButNotTheStation()
    {
        var train = new Train(1000, 0, 0, 0, 500, 5, 0);
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new StationArea(15, 10, 30));
        var travel = new Travel(collectionOfAreas);
        FinalResult finish = travel.Drive(train, 5);
        bool trainResult = finish is AreaResult.MaximumPermissibleSpeed;
        Assert.True(trainResult);
    }

    [Fact]
    public void SpeedReductionCheckForStationAndRoute()
    {
        var train = new Train(1000, 0, 0, 0, 500, 5, 0);
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 500));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new PowerArea(100, -130));
        collectionOfAreas.Add(new StationArea(15, 10, 30));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new PowerArea(100, 500));
        collectionOfAreas.Add(new NormalArea(100));
        collectionOfAreas.Add(new PowerArea(100, -400));
        var travel = new Travel(collectionOfAreas);
        FinalResult finish = travel.Drive(train, 100);
        bool trainResult = finish is FinalResult.TravelSuccessResult;
        Assert.True(trainResult);
    }

    [Fact]
    public void TheresNoAcceleration()
    {
        var train = new Train(1000, 0, 0, 0, 500, 5, 0);
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new NormalArea(100));
        var travel = new Travel(collectionOfAreas);
        FinalResult finish = travel.Drive(train, 6);
        bool trainResult = finish is TrainResult.TheTrainHasNoSpeed;
        Assert.True(trainResult);
    }

    [Fact]
    public void TheTrainCouldntWithstandTheForceApplied()
    {
        var train = new Train(1000, 0, 0, 0, 500, 5, 0);
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 1000));
        collectionOfAreas.Add(new PowerArea(100, -2000));
        var travel = new Travel(collectionOfAreas);
        FinalResult finish = travel.Drive(train, 6);

        bool trainResult = finish is TrainResult.TheTrainCouldntHandleTheAcceleration;
        Assert.True(trainResult);
    }
}
