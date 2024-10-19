using Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Service;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

public class PowerArea : IArea
{
    private readonly TrainService _trainService;

    public PowerArea(int distance, int power, TrainService trainService)
    {
        Distance = distance;
        Power = power;
        _trainService = trainService;
    }

    public int Power { get; set; }

    public int Distance { get; set; }

    public Result Move(Train train)
    {
        return _trainService.MovePowerArea(train, Power, Distance);
    }
}