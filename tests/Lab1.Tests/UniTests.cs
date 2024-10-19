using Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Service;

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
        double expected = 41.819888461721021;
        Assert.True(result);
        Assert.Equal(res.Result, expected);
    }
}

// [Fact]
//     public void CheckingThePermissibleSpeedOfAnOverspeedRoute()
//     {
//         var collectionOfAreas = new Collection<IArea>();
//         collectionOfAreas.Add(new PowerArea(100, 300));
//         collectionOfAreas.Add(new NormalArea(100));
//
//         var train = new Train(1000, 0, 0, 0, 500, 5, 0);
//
//         TrainResult finish = Travel.Drive(train, collectionOfAreas, 1);
//
//         bool trainResult = finish is TrainResult.MaximumPermissibleSpeed;
//         Assert.True(trainResult);
//     }
//
//     [Fact]
//     public void CheckingThePermissibleSpeedOnTheRouteAndStationWithPassingThe()
//     {
//         var collectionOfAreas = new Collection<IArea>();
//         collectionOfAreas.Add(new PowerArea(100, 300));
//         collectionOfAreas.Add(new NormalArea(100));
//         collectionOfAreas.Add(new StationArea(15, 10, 30));
//
//         var train = new Train(1000, 0, 0, 0, 500, 5, 0);
//
//         TrainResult finish = Travel.Drive(train, collectionOfAreas, 10);
//
//         bool trainResult = finish is TrainResult.Success;
//         Assert.True(trainResult);
//         var res = (TrainResult.Success)finish;
//         double expected = 71.819888461721021;
//         Assert.Equal(res.TrainResult, expected);
//     }
//
//     [Fact]
//     public void CheckOfThePermissibleSpeedOfPassingTheStationWithExcessiveSpeed()
//     {
//         var collectionOfAreas = new Collection<IArea>();
//         collectionOfAreas.Add(new PowerArea(100, 300));
//         collectionOfAreas.Add(new NormalArea(100));
//         collectionOfAreas.Add(new StationArea(15, 5, 30));
//
//         var train = new Train(1000, 0, 0, 0, 500, 5, 0);
//
//         TrainResult finish = Travel.Drive(train, collectionOfAreas, 10);
//
//         bool trainResult = finish is TrainResult.TheStationDidNotStopTheTrain;
//         Assert.True(trainResult);
//     }
//
//     [Fact]
//     public void AccelerationToTheAllowableSpeedOfTheRouteButNotTheStation()
//     {
//         var collectionOfAreas = new Collection<IArea>();
//         collectionOfAreas.Add(new PowerArea(100, 300));
//         collectionOfAreas.Add(new NormalArea(100));
//         collectionOfAreas.Add(new StationArea(15, 10, 30));
//
//         var train = new Train(1000, 0, 0, 0, 500, 5, 0);
//
//         TrainResult finish = Travel.Drive(train, collectionOfAreas, 5);
//
//         bool trainResult = finish is TrainResult.MaximumPermissibleSpeed;
//         Assert.True(trainResult);
//     }
//
//     [Fact]
//     public void SpeedReductionCheckForStationAndRoute()
//     {
//         var collectionOfAreas = new Collection<IArea>();
//         collectionOfAreas.Add(new PowerArea(100, 500));
//         collectionOfAreas.Add(new NormalArea(100));
//         collectionOfAreas.Add(new PowerArea(100, -130));
//         collectionOfAreas.Add(new StationArea(15, 10, 30));
//         collectionOfAreas.Add(new NormalArea(100));
//         collectionOfAreas.Add(new PowerArea(100, 500));
//         collectionOfAreas.Add(new NormalArea(100));
//         collectionOfAreas.Add(new PowerArea(100, -400));
//
//         var train = new Train(1000, 0, 0, 0, 500, 5, 0);
//
//         TrainResult finish = Travel.Drive(train, collectionOfAreas, 100);
//
//         bool trainResult = finish is TrainResult.Success;
//         Assert.True(trainResult);
//         var res = (TrainResult.Success)finish;
//         double expected = 178.58390735538438;
//         Assert.Equal(res.TrainResult, expected);
//     }
//
//     [Fact]
//     public void TheresNoAcceleration()
//     {
//         var collectionOfAreas = new Collection<IArea>();
//         collectionOfAreas.Add(new NormalArea(100));
//
//         var train = new Train(1000, 0, 0, 0, 500, 5, 0);
//
//         TrainResult finish = Travel.Drive(train, collectionOfAreas, 6);
//
//         bool trainResult = finish is TrainResult.TheTrainHasNoSpeed;
//         Assert.True(trainResult);
//     }
//
//     [Fact]
//     public void TheTrainCouldntWithstandTheForceApplied()
//     {
//         var collectionOfAreas = new Collection<IArea>();
//         collectionOfAreas.Add(new PowerArea(100, 1000));
//         collectionOfAreas.Add(new PowerArea(100, -2000));
//
//         var train = new Train(1000, 0, 0, 0, 500, 5, 0);
//
//         TrainResult finish = Travel.Drive(train, collectionOfAreas, 6);
//
//         bool trainResult = finish is TrainResult.TheTrainCouldntHandleTheAcceleration;
//         Assert.True(trainResult);
//     }
// }
