using Itmo.ObjectOrientedProgramming.Lab1.Entity.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Areas;

public class StationArea(int distance, int stopSpeed, int time) : BaseArea(distance)
{
    private int StopSpeed { get; } = stopSpeed;

    private int Time { get; } = time;

    public override Result Move(Train train)
    {
        if (train.Speed > StopSpeed)
        {
            return new Result.TheStationDidNotStopTheTrain();
        }

        train.Time += Time;
        return base.Move(train);
    }
}