using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

public class NormalArea(int distance) : BaseArea(distance)
{
    public override Result Move(Train train)
    {
        if (train.Speed <= 0)
        {
            return new Result.TheTrainHasNoSpeed();
        }

        train.Time += Distance / train.Speed;

        return base.Move(train);
    }
}