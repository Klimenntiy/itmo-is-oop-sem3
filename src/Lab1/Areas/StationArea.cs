// <copyright file="StationArea.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Itmo.ObjectOrientedProgramming.Lab1.Model;

namespace Itmo.ObjectOrientedProgramming.Lab1.Areas;

public class StationArea(int time, int stopSpeed) : IArea
{
    public Result Move(Train train)
    {
        if (train.Speed > stopSpeed)
        {
            return new Result.TheStationDidNotStopTheTrain();
        }

        train.Time += time;
        return new Result.Success();
    }
}