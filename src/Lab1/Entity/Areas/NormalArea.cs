using Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Service;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

public class NormalArea : IArea
{
    private readonly TrainService _trainService;

    public int Distance { get; set; }

    public NormalArea(int distance, TrainService trainService)
    {
        Distance = distance;
        _trainService = trainService;
    }

    public Result Move(Train train)
    {
        return _trainService.MoveNormalArea(train, Distance);
    }
}