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
        var trainService = new TrainService();
        var train = new Train(1000, 0, 0, 0, 500, 5, 0);
        var collectionOfAreas = new List<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300, trainService));
        collectionOfAreas.Add(new NormalArea(100, trainService));
        var travel = new Travel(collectionOfAreas);
        Result finish = travel.Drive(train, 10);

        bool result = finish is Result.TravelSuccessResult;
        var res = (Result.TravelSuccessResult)finish;
        Assert.True(result);
    }

    [Fact]
    public void CheckingThePermissibleSpeedOfAnOverspeedRoute()
    {
        var trainService = new TrainService();
        var train = new Train(1000, 0, 0, 0, 500, 5, 0);
        var collectionOfAreas = new List<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300, trainService));
        collectionOfAreas.Add(new NormalArea(100, trainService));
        var travel = new Travel(collectionOfAreas);
        Result finish = travel.Drive(train, 1);

        bool trainResult = finish is Result.MaximumPermissibleSpeed;
        Assert.True(trainResult);
    }

    [Fact]
    public void CheckingThePermissibleSpeedOnTheRouteAndStationWithPassingThe()
    {
        var trainService = new TrainService();
        var train = new Train(1000, 0, 0, 0, 500, 5, 0);
        var collectionOfAreas = new List<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300, trainService));
        collectionOfAreas.Add(new NormalArea(100, trainService));
        collectionOfAreas.Add(new StationArea(15, 10, 30, trainService));
        var travel = new Travel(collectionOfAreas);
        Result finish = travel.Drive(train, 10);

        bool trainResult = finish is Result.TravelSuccessResult;
        Assert.True(trainResult);
    }

    [Fact]
    public void CheckOfThePermissibleSpeedOfPassingTheStationWithExcessiveSpeed()
    {
        var trainService = new TrainService();
        var train = new Train(1000, 0, 0, 0, 500, 5, 0);
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300, trainService));
        collectionOfAreas.Add(new NormalArea(100, trainService));
        collectionOfAreas.Add(new StationArea(15, 5, 30, trainService));
        var travel = new Travel(collectionOfAreas);
        Result finish = travel.Drive(train, 10);

        bool trainResult = finish is Result.TheStationDidNotStopTheTrain;
        Assert.True(trainResult);
    }

    [Fact]
    public void AccelerationToTheAllowableSpeedOfTheRouteButNotTheStation()
    {
        var trainService = new TrainService();
        var train = new Train(1000, 0, 0, 0, 500, 5, 0);
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 300, trainService));
        collectionOfAreas.Add(new NormalArea(100, trainService));
        collectionOfAreas.Add(new StationArea(15, 10, 30, trainService));
        var travel = new Travel(collectionOfAreas);
        Result finish = travel.Drive(train, 5);

        bool trainResult = finish is Result.MaximumPermissibleSpeed;
        Assert.True(trainResult);
    }

    [Fact]
    public void SpeedReductionCheckForStationAndRoute()
    {
        var trainService = new TrainService();
        var train = new Train(1000, 0, 0, 0, 500, 5, 0);
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 500, trainService));
        collectionOfAreas.Add(new NormalArea(100, trainService));
        collectionOfAreas.Add(new PowerArea(100, -130, trainService));
        collectionOfAreas.Add(new StationArea(15, 10, 30, trainService));
        collectionOfAreas.Add(new NormalArea(100, trainService));
        collectionOfAreas.Add(new PowerArea(100, 500, trainService));
        collectionOfAreas.Add(new NormalArea(100, trainService));
        collectionOfAreas.Add(new PowerArea(100, -400, trainService));
        var travel = new Travel(collectionOfAreas);
        Result finish = travel.Drive(train, 100);

        bool trainResult = finish is Result.TravelSuccessResult;
        Assert.True(trainResult);
    }

    [Fact]
    public void TheresNoAcceleration()
    {
        var trainService = new TrainService();
        var train = new Train(1000, 0, 0, 0, 500, 5, 0);
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new NormalArea(100, trainService));
        var travel = new Travel(collectionOfAreas);
        Result finish = travel.Drive(train, 6);

        bool trainResult = finish is Result.TheTrainHasNoSpeed;
        Assert.True(trainResult);
    }

    [Fact]
    public void TheTrainCouldntWithstandTheForceApplied()
    {
        var trainService = new TrainService();
        var train = new Train(1000, 0, 0, 0, 500, 5, 0);
        var collectionOfAreas = new Collection<IArea>();
        collectionOfAreas.Add(new PowerArea(100, 1000, trainService));
        collectionOfAreas.Add(new PowerArea(100, -2000, trainService));
        var travel = new Travel(collectionOfAreas);
        Result finish = travel.Drive(train, 6);

        bool trainResult = finish is Result.TheTrainCouldntHandleTheAcceleration;
        Assert.True(trainResult);
    }
}
