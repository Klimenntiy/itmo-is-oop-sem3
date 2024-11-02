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

    public FinalResult Drive(Train train, int maxSpeed)
    {
        Train currentTrain = train;
        foreach (IArea area in _areas)
        {
            FinalResult trainResult = area.Move(currentTrain);
            if (trainResult is not FinalResult.TravelSuccessResult)
            {
                return trainResult;
            }
        }

        if (currentTrain.Speed > maxSpeed)
        {
            return new AreaResult.MaximumPermissibleSpeed();
        }

        return new FinalResult.TravelSuccessResult();
    }
}