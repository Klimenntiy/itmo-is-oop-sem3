using Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Model;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service;

public class Travel
{
    private readonly IReadOnlyCollection<IArea> _areas;

    public Travel(IReadOnlyCollection<IArea> areas)
    {
        _areas = areas;
    }

    public Result Drive(Train train, int maxSpeed)
    {
        foreach (IArea area in _areas)
        {
            Result trainResult = area.Move(train);
            if (trainResult is not Result.TravelSuccessResult)
            {
                return trainResult;
            }
        }

        if (train.Speed > maxSpeed)
        {
            return new Result.MaximumPermissibleSpeed();
        }

        return new Result.TravelSuccessResult(train.Time);
    }
}