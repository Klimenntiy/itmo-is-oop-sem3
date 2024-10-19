using Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Service;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

public class StationArea : IArea
{
    private readonly TrainService _trainService;

    public StationArea(int distance, uint stopSpeed, uint stopTime, TrainService trainService)
    {
        StopSpeed = stopSpeed;
        StopTime = stopTime;
        _trainService = trainService;
        Distance = distance;
    }

    public uint StopSpeed { get; set; }

    public uint StopTime { get; set; }

    public int Distance { get; set; }

    public Result Move(Train train)
    {
        return _trainService.MoveStationArea(train, Distance, StopSpeed, StopSpeed);
    }
}