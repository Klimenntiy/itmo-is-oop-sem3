using Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Model;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service;

public class Travel
{
    public static Result Drive(Train train, Collection<IArea> areas, int maxSpeed)
    {
        foreach (IArea area in areas)
        {
            Result result = area.Move(train);
            if (result is not Result.Success)
            {
                return result;
            }
        }

        if (train.Speed > maxSpeed)
        {
            return new Result.MaximumPermissibleSpeed();
        }

        return new Result.Success(train.Time);
    }
}